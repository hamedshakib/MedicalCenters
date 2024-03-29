﻿namespace MedicalCenters.Domain.Enums
{
    public enum ErrorEnums
    {
        UnKnown = -1,
        Validation = 1,
        NotFound = 2,
        ConvertData = 3,
        Query = 4,
        LoginFailed = 5,
        UnAuthorized = 6,
        TaskCanceled = 7,
        TokenBlocked = 8,
        UserOverLimitRequested = 9,
        RefreshTokenFailed = 10,
    }
}
