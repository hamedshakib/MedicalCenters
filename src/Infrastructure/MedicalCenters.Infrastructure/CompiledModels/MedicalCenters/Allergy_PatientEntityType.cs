﻿// <auto-generated />
using System;
using System.Reflection;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.IntermediateEntities;
using MedicalCenters.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;

#pragma warning disable 219, 612, 618
#nullable disable

namespace MedicalCenters.Persistence.CompiledModels.MedicalCenters
{
    internal partial class Allergy_PatientEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "MedicalCenters.Domain.Entities.IntermediateEntities.Allergy_Patient",
                typeof(Allergy_Patient),
                baseEntityType);

            var allergyId = runtimeEntityType.AddProperty(
                "AllergyId",
                typeof(int),
                propertyInfo: typeof(Allergy_Patient).GetProperty("AllergyId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Allergy_Patient).GetField("<AllergyId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0);
            allergyId.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v));
            allergyId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var patientId = runtimeEntityType.AddProperty(
                "PatientId",
                typeof(long),
                propertyInfo: typeof(Allergy_Patient).GetProperty("PatientId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Allergy_Patient).GetField("<PatientId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0L);
            patientId.TypeMapping = SqlServerLongTypeMapping.Default.Clone(
                comparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                keyComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                providerValueComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v));
            patientId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime?),
                propertyInfo: typeof(BaseCreatableDomainEntity).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(BaseCreatableDomainEntity).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            createdAt.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                keyComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                providerValueComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)));
            createdAt.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdBy = runtimeEntityType.AddProperty(
                "CreatedBy",
                typeof(long),
                propertyInfo: typeof(BaseCreatableDomainEntity).GetProperty("CreatedBy", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(BaseCreatableDomainEntity).GetField("<CreatedBy>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0L);
            createdBy.TypeMapping = SqlServerLongTypeMapping.Default.Clone(
                comparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                keyComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                providerValueComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v));
            createdBy.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { allergyId, patientId });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { patientId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("AllergyId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var allergy = declaringEntityType.AddNavigation("Allergy",
                runtimeForeignKey,
                onDependent: true,
                typeof(Allergy),
                propertyInfo: typeof(Allergy_Patient).GetProperty("Allergy", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Allergy_Patient).GetField("<Allergy>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("PatientId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var patient = declaringEntityType.AddNavigation("Patient",
                runtimeForeignKey,
                onDependent: true,
                typeof(Patient),
                propertyInfo: typeof(Allergy_Patient).GetProperty("Patient", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Allergy_Patient).GetField("<Patient>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Allergy_Patient");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
