این پروژه ی مراکز درمانی می باشد.

برای ساخت و اعمال migration برای این پروژه از دستورات زیر استفاده کرد:

Add-Migration InitialCreate -Context MedicalCentersDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
Update-Database -Context MedicalCentersDBContext -StartupProject MedicalCenters.API

Add-Migration InitialCreate -Context IdentityDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
Update-Database -Context IdentityDBContext -StartupProject MedicalCenters.API

همچنین برای بهینه سازی DbContext نیز می توان از دستورات زیر استفاده نمایید:

Optimize-DbContext -OutputDir CompiledModels/MedicalCenters -Context MedicalCentersDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
Optimize-DbContext -OutputDir CompiledModels/Identity -Context IdentityDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API

