using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Model;

namespace LMS.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<UserInfo> UserInfos { get; set; }   
    public DbSet<OTPSend> SaveVerifyOTP { get; set; }
    public DbSet<Login> ClientLogin { get; set; }
    
//    protected override void OnConfiguring(DbContextOptionsBuilder options)
//     => options.UseNpgsql("host=postgres;port=5432;database=LMSTESTING;username=bloguser;password=bloguser");

}

