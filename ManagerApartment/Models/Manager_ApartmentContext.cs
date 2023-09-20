using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManagerApartment.Models
    // File Connect DB
{
    public partial class Manager_ApartmentContext : DbContext
    {
        public Manager_ApartmentContext()
        {
        }

        public Manager_ApartmentContext(DbContextOptions<Manager_ApartmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; } = null!;
        public virtual DbSet<ApartmentType> ApartmentTypes { get; set; } = null!;
        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetHistory> AssetHistories { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<RequestLog> RequestLogs { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceDetail> ServiceDetails { get; set; } = null!;
        public virtual DbSet<StaffLog> StaffLogs { get; set; } = null!;
        public virtual DbSet<Tennant> Tennants { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=Manager_Apartment;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.ApartmentStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApartmentTypeId).HasColumnName("ApartmentTypeID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.ApartmentType)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.ApartmentTypeId)
                    .HasConstraintName("FK__Apartment__Apart__2A4B4B5E");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK__Apartment__Build__2B3F6F97");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Apartment__Owner__2C3393D0");
            });

            modelBuilder.Entity<ApartmentType>(entity =>
            {
                entity.ToTable("ApartmentType");

                entity.Property(e => e.ApartmentTypeId).HasColumnName("ApartmentTypeID");

                entity.Property(e => e.ApartmentTypeDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApartmentTypeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApartmentTypeStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.AssetDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AssetHistoryId).HasColumnName("AssetHistoryID");

                entity.Property(e => e.AssetItemImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AssetName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AssetStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.ApartmentId)
                    .HasConstraintName("FK__Asset__Apartment__37A5467C");

                entity.HasOne(d => d.AssetHistory)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.AssetHistoryId)
                    .HasConstraintName("FK__Asset__AssetHist__36B12243");
            });

            modelBuilder.Entity<AssetHistory>(entity =>
            {
                entity.ToTable("Asset_History");

                entity.Property(e => e.AssetHistoryId).HasColumnName("AssetHistoryID");

                entity.Property(e => e.AssetHisItemImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AssetHisStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.BillStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__Bill__RequestID__440B1D61");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("Building");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.BuildingAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.ContractImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContractStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.TennantId).HasColumnName("TennantID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ApartmentId)
                    .HasConstraintName("FK__Contract__Apartm__30F848ED");

                entity.HasOne(d => d.Tennant)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.TennantId)
                    .HasConstraintName("FK__Contract__Tennan__31EC6D26");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OwnerAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.BookDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ReqDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReqStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ApartmentId)
                    .HasConstraintName("FK__Requests__Apartm__3E52440B");
            });

            modelBuilder.Entity<RequestLog>(entity =>
            {
                entity.ToTable("Request_Log");

                entity.Property(e => e.RequestLogId).HasColumnName("RequestLogID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MaintainItem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegLogStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReqLogDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestLogs)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__Request_L__Reque__412EB0B6");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("ServiceID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServicePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ServiceStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.ToTable("Service_Detail");

                entity.Property(e => e.ServiceDetailId).HasColumnName("ServiceDetailID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemBillImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.SerDeDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SerDePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SerDeStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ServiceDetails)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__Service_D__Reque__47DBAE45");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Service_D__Servi__46E78A0C");
            });

            modelBuilder.Entity<StaffLog>(entity =>
            {
                entity.ToTable("Staff_Log");

                entity.Property(e => e.StaffLogId).HasColumnName("StaffLogID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.RequestLogId).HasColumnName("RequestLogID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.RequestLog)
                    .WithMany(p => p.StaffLogs)
                    .HasForeignKey(d => d.RequestLogId)
                    .HasConstraintName("FK__Staff_Log__Reque__4BAC3F29");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffLogs)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Staff_Log__Staff__4AB81AF0");
            });

            modelBuilder.Entity<Tennant>(entity =>
            {
                entity.ToTable("Tennant");

                entity.Property(e => e.TennantId).HasColumnName("TennantID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.TennantAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TennantEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TennantName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TennantPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TennantPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TennantStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StaffStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
