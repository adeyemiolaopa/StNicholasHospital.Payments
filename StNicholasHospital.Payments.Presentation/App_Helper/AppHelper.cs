using StNicholasHospital.Payments.Domain.Dto;
using StNicholasHospital.Payments.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace StNicholasHospital.Payments.Presentation.App_Helper
{
    public class AppHelper
    {
        private static MemoryCache cache = MemoryCache.Default;

        public static void AddStaffToCache(StaffDto staff)
        {
            var policy = new CacheItemPolicy();
            policy.SlidingExpiration = new TimeSpan(0, 60, 0);
            cache.Add(staff.StaffNo.ToString(), staff, policy);
        }

        public static StaffDto GetStaffFromCache(string staffID)
        {
            var staff = (StaffDto) cache.Get(staffID);
            return staff;
        }

        public static void RemoveUserFromCache(string apiKey)
        {
            if (cache[apiKey] != null) {
                cache.Remove(apiKey);
            }
        }
    }
}