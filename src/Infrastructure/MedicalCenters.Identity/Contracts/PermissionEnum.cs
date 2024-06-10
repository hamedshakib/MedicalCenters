using MedicalCenters.Identity.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Contracts
{
    public enum PermissionEnum
    {
        [Description("افزودن مرکز درمانی")]
        AddMedicalCenter = 1,
        [Description("ویرایش مرکز درمانی")]
        EditMedicalCenter = 2,
        [Description("حذف مرکز درمانی")]
        DeleteMedicalCenter = 3,
        [Description("مشاهده اطلاعات مرکز درمانی")]
        SeeMedicalCenterInfo = 4,
        [Description("مشاهده اطلاعات تمامی مراکز درمانی")]
        SeeAllMedicalCentersInfos = 5,
        [Description("افزودن بخش درمانی")]
        AddMedicalWard = 6,
        [Description("ویرایش بخش درمانی")]
        EditMedicalWard = 7,
        [Description("حذف بخش درمانی")]
        DeleteMedicalWard =8,
        [Description("مشاهده اطلاعات بخش درمانی")]
        SeeMedicalWardInfo = 9,
        [Description("مشاهده اطلاعات تمامی بخش های مرکز درمانی")]
        SeeAllMedicalCenterWardsInfos = 10,
        [Description("افزودن دارو")]
        AddMedicine = 11,
        [Description("ویرایش دارو")]
        EditMedicine = 12,
        [Description("حذف دارو")]
        DeleteMedicine = 13,
        [Description("مشاهده دارو ها")]
        SeeMedicines = 14,
        [Description("مشاهده دارو های یک نوع")]
        SeeAllMedicineTypeMedicinesInfos = 15,
    }
}