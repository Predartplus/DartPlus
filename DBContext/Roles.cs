﻿using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public required string RoleName { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}