using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabProject.Models;
using Microsoft.AspNetCore.Identity;

namespace LabProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
   
}

