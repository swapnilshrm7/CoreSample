using Core.Contracts;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GuardService
{
    public class GuardManager : IGuard
    {
        static List<GuardData> AllLogs = new List<GuardData>();
        public bool UserValidation(string GuardId, string Password)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                List<GuardLogs> guardsLogs = entity.GuardLogs.FromSql("select * from VisitorsLogs where GuardId = @Id and GuardPassword = @Password", new SqlParameter("@Id", GuardId), new SqlParameter("@Password", Password)).ToList<GuardLogs>();

                if (guardsLogs.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Validation Failed! Please Contact Admin"+ex.StackTrace);
            }
        }
        public List<GuardData> GetAllGuardsFromLog()
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                List<GuardLogs> guardLogsList = entity.GuardLogs.FromSql("select * from GuardLogs").ToList<GuardLogs>();
                foreach (var entry in guardLogsList)
                {
                    GetGuardData(entry);
                }
                return AllLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Guard Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
        public static void GetGuardData(GuardLogs guard)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                Guard guardData = entity.Guard.Find(guard.GuardId);
                GuardData entry = new GuardData();

                entry.GuardId = guard.GuardId;
                entry.SerialNumber = guard.SerialNumber;
                entry.GuardPassword = guard.GuardPassword;
                entry.LoginTime = guard.LoginTime;
                entry.LogoutTime = guard.LogoutTime;
                entry.GuardName = guardData.GuardName;
                entry.EmailId = guardData.EmailId;
                entry.GuardStatus = guardData.GuardStatus;
                entry.Gender = guardData.Gender;
                entry.DateOfBirth = guardData.DateOfBirth;
                entry.LocalAddress = guardData.LocalAddress;
                entry.PermanentAddress = guardData.PermanentAddress;
                entry.EmergencyContactPerson = guardData.EmergencyContactPerson;
                entry.EmergencyContactNumber = guardData.EmergencyContactNumber;
                entry.PrimaryContactNumber = guardData.PrimaryContactNumber;
                entry.SecondaryContactNumber = guardData.SecondaryContactNumber;
                entry.DateOfJoining = guardData.DateOfJoining;
                entry.DateOfResignation = guardData.DateOfResignation;
                entry.Remark = guardData.Remark;
                entry.BloodGroup = guardData.BloodGroup;
                entry.MedicalSpecification = guardData.MedicalSpecification;
                AllLogs.Add(entry);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Error: GetGuardData" + ex.StackTrace);
            }
        }
        public List<GuardData> GetGuardsLogByName(string searchInput)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                List<Guard> guardLogsList = entity.Guard.FromSql("select * from Guard where GuardName  = @searchInput", new SqlParameter("@searchInput", searchInput)).ToList<Guard>();
                foreach (var entry in guardLogsList)
                {
                    GetGuardDataByName(entry);
                }
                return AllLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Guard Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
        public void GetGuardDataByName(Guard guard)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                List<GuardLogs> guardData = entity.GuardLogs.FromSql("select * from GuardLogs where GuardId = @searchInput", new SqlParameter("@searchInput", guard.GuardId)).ToList<GuardLogs>();
                foreach (var result in guardData)
                {
                    GuardData entry = new GuardData();
                    entry.GuardId = guard.GuardId;
                    entry.GuardName = guard.GuardName;
                    entry.EmailId = guard.EmailId;
                    entry.GuardStatus = guard.GuardStatus;
                    entry.Gender = guard.Gender;
                    entry.DateOfBirth = guard.DateOfBirth;
                    entry.LocalAddress = guard.LocalAddress;
                    entry.PermanentAddress = guard.PermanentAddress;
                    entry.EmergencyContactNumber = guard.EmergencyContactNumber;
                    entry.EmergencyContactPerson = guard.EmergencyContactPerson;
                    entry.PrimaryContactNumber = guard.PrimaryContactNumber;
                    entry.DateOfJoining = guard.DateOfJoining;
                    entry.Remark = guard.Remark;
                    entry.BloodGroup = guard.BloodGroup;
                    entry.MedicalSpecification = guard.MedicalSpecification;
                    entry.SerialNumber = result.SerialNumber;
                    entry.LoginTime = result.LoginTime;
                    entry.LogoutTime = result.LogoutTime;

                    if (guard.GuardStatus.Equals("Active"))
                    {
                        entry.DateOfResignation = guard.DateOfResignation;
                    }
                    AllLogs.Add(entry);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Error: GetGuardDataByName" + ex.StackTrace);
            }
        }
        //public List<Guard> GetUniqueGuards()
        //{

        //}
    }
}

