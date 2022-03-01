# LMS
Yoctel License Management System

# Branches
**main** : produciton branch <br />
**stage** : testing branch <br />
**dev** : for development <br />
**other** branch: dev should create by their profile name or by ticket name, once they are done they can create a pull request to dev branch, dev branch should not be used directly <br />

# Prerequisite
You should have docker and docker compose on your local system

# How to Run
docker-compose up --build
try sudo(admin) if required


# How to Run Migration
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
{
# This Code UnCommented
}


# How to Add Migration 
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
{
# This Code Commented
}