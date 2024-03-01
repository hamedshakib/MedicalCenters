using MedicalCenters.Cache;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Classes
{
    internal static class OverLimitRequestChecker
    {
        private static int burst = 15;
        private static float emission_interval = 1.5f;

        private static string Lua_Script = @"
                                redis.replicate_commands()

                                local rate_limit_key = @rate_limit_key
                                local burst = @burst
                                local emission_interval = tonumber(@emission_interval)

                                local jan_1_2017 = 1483228800
                                local now = redis.call(""TIME"")
                                now = (now[1] - jan_1_2017) + (now[2] / 1000000)

                                -- if tat does not exists, creates a new one 
                                local tat = redis.call(""GET"", rate_limit_key)
                                if not tat then
                                    tat = now
                                else
                                    tat = tonumber(tat)
                                end

                                tat = math.max(tat, now)

                                local burst_offset = emission_interval * burst
                                local allow_at = tat - burst_offset
                                local diff = now - allow_at
                                if diff < 0 then
                                    return {
                                        0, -- allowed
                                        0, -- remaining
                                        tostring(-diff) -- wait for
                                    }
                                end

                                local new_tat = tat + emission_interval
                                local key_expiration = new_tat - now

                                redis.call(""SET"", rate_limit_key, new_tat, ""EX"", math.ceil(key_expiration))

                                return {
                                    1, -- allowed
                                    tostring(math.ceil(diff / emission_interval)), -- remaining
                                    0,
                                }
                                  ";

        public static bool Check(long UserId)
        {
            var luaPrepare = LuaScript.Prepare(Lua_Script);
            string Key = $"USERS:{UserId}:RequestRateLimit";

            var res = luaPrepare.Evaluate(RedisDatabase.Database, new
            {
                rate_limit_key = Key,
                burst = burst.ToString(),
                emission_interval = emission_interval.ToString()
            });
            var items = ((RedisResult[]?)res);
            bool isAcceptable = Convert.ToBoolean(items[0]);
            return isAcceptable;
        }
    }
}
