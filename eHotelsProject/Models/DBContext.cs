using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eHotelsProject.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amenity> Amenity { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Artwork> Artwork { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Bookingarc> Bookingarc { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customer1> Customer1 { get; set; }
        public virtual DbSet<Damage> Damage { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Hotelchain> Hotelchain { get; set; }
        public virtual DbSet<Hotelchainemail> Hotelchainemail { get; set; }
        public virtual DbSet<Hotelchainphone> Hotelchainphone { get; set; }
        public virtual DbSet<Hotelphone> Hotelphone { get; set; }
        public virtual DbSet<Likeartist> Likeartist { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Renting> Renting { get; set; }
        public virtual DbSet<Rentingarc> Rentingarc { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=DB;Username=postgres;Password=password1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("amenity_pkey");

                entity.ToTable("amenity", "project");

                entity.Property(e => e.Aid)
                    .HasColumnName("aid")
                    .HasDefaultValueSql("nextval('project.amenity_aid_seq'::regclass)");

                entity.Property(e => e.Amenity1)
                    .IsRequired()
                    .HasColumnName("amenity");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Amenity)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("amenity_room_fkey");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.Aname)
                    .HasName("artist_pkey");

                entity.ToTable("artist", "laboratories");

                entity.Property(e => e.Aname)
                    .HasColumnName("aname")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthplace)
                    .HasColumnName("birthplace")
                    .HasMaxLength(20);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(20);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.Style)
                    .HasColumnName("style")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("artwork_pkey");

                entity.ToTable("artwork", "laboratories");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aname)
                    .HasColumnName("aname")
                    .HasMaxLength(20);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.AnameNavigation)
                    .WithMany(p => p.Artwork)
                    .HasForeignKey(d => d.Aname)
                    .HasConstraintName("artwork_aname_fkey");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("booking_pkey");

                entity.ToTable("booking", "project");

                entity.Property(e => e.Bid)
                    .HasColumnName("bid")
                    .HasDefaultValueSql("nextval('project.booking_bid_seq'::regclass)");

                entity.Property(e => e.CustomerSsn).HasColumnName("customer_ssn");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.HasOne(d => d.CustomerSsnNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.CustomerSsn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_customer_fkey");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_room_fkey");
            });

            modelBuilder.Entity<Bookingarc>(entity =>
            {
                entity.HasKey(e => e.Baid)
                    .HasName("bookingarc_pkey");

                entity.ToTable("bookingarc", "project");

                entity.Property(e => e.Baid)
                    .HasColumnName("baid")
                    .HasDefaultValueSql("nextval('project.bookingarc_baid_seq'::regclass)");

                entity.Property(e => e.CustomerSsn).HasColumnName("customer_ssn");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.StartDate).HasColumnName("start_date");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("customer_pkey");

                entity.ToTable("customer", "project");

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfEmployment)
                    .HasColumnName("date_of_employment")
                    .HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.SsnNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Ssn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_person_fkey");
            });

            modelBuilder.Entity<Customer1>(entity =>
            {
                entity.HasKey(e => e.Custid)
                    .HasName("customer_pkey");

                entity.ToTable("customer", "laboratories");

                entity.Property(e => e.Custid)
                    .HasColumnName("custid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(20);

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            modelBuilder.Entity<Damage>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("damage_pkey");

                entity.ToTable("damage", "project");

                entity.Property(e => e.Did)
                    .HasColumnName("did")
                    .HasDefaultValueSql("nextval('project.damage_did_seq'::regclass)");

                entity.Property(e => e.Damage1)
                    .IsRequired()
                    .HasColumnName("damage");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("damage_room_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("employee_pkey");

                entity.ToTable("employee", "project");

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfEmployment)
                    .HasColumnName("date_of_employment")
                    .HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.SsnNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Ssn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_person_fkey");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.Hid)
                    .HasName("hotel_pkey");

                entity.ToTable("hotel", "project");

                entity.Property(e => e.Hid)
                    .HasColumnName("hid")
                    .HasDefaultValueSql("nextval('project.hotel_hid_seq'::regclass)");

                entity.Property(e => e.AptNumber).HasColumnName("apt_number");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(355);

                entity.Property(e => e.HState)
                    .IsRequired()
                    .HasColumnName("h_state")
                    .HasMaxLength(50);

                entity.Property(e => e.Hcid).HasColumnName("hcid");

                entity.Property(e => e.Manager).HasColumnName("manager");

                entity.Property(e => e.NumRooms).HasColumnName("num_rooms");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("street_name")
                    .HasMaxLength(50);

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(6);

                entity.HasOne(d => d.Hc)
                    .WithMany(p => p.Hotel)
                    .HasForeignKey(d => d.Hcid)
                    .HasConstraintName("hotel_hotelchain_fkey");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.Hotel)
                    .HasForeignKey(d => d.Manager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hotel_employee_fkey");
            });

            modelBuilder.Entity<Hotelchain>(entity =>
            {
                entity.HasKey(e => e.Hcid)
                    .HasName("hotelchain_pkey");

                entity.ToTable("hotelchain", "project");

                entity.Property(e => e.Hcid)
                    .HasColumnName("hcid")
                    .HasDefaultValueSql("nextval('project.hotelchain_hcid_seq'::regclass)");

                entity.Property(e => e.AptNumber).HasColumnName("apt_number");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.HcState)
                    .IsRequired()
                    .HasColumnName("hc_state")
                    .HasMaxLength(50);

                entity.Property(e => e.NumHotels).HasColumnName("num_hotels");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("street_name")
                    .HasMaxLength(50);

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Hotelchainemail>(entity =>
            {
                entity.HasKey(e => new { e.Email, e.Hcid })
                    .HasName("hotelchainemail_pkey");

                entity.ToTable("hotelchainemail", "project");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(355);

                entity.Property(e => e.Hcid).HasColumnName("hcid");

                entity.HasOne(d => d.Hc)
                    .WithMany(p => p.Hotelchainemail)
                    .HasForeignKey(d => d.Hcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("email_hotelchain_fkey");
            });

            modelBuilder.Entity<Hotelchainphone>(entity =>
            {
                entity.HasKey(e => new { e.PhoneNumber, e.Hcid })
                    .HasName("hotelchainphone_pkey");

                entity.ToTable("hotelchainphone", "project");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Hcid).HasColumnName("hcid");

                entity.HasOne(d => d.Hc)
                    .WithMany(p => p.Hotelchainphone)
                    .HasForeignKey(d => d.Hcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("phone_hotelchain_fkey");
            });

            modelBuilder.Entity<Hotelphone>(entity =>
            {
                entity.HasKey(e => new { e.PhoneNumber, e.Hid })
                    .HasName("hotelphone_pkey");

                entity.ToTable("hotelphone", "project");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Hid).HasColumnName("hid");

                entity.HasOne(d => d.H)
                    .WithMany(p => p.Hotelphone)
                    .HasForeignKey(d => d.Hid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("phone_hotel_fkey");
            });

            modelBuilder.Entity<Likeartist>(entity =>
            {
                entity.HasKey(e => new { e.Aname, e.Custid })
                    .HasName("likeartist_pkey");

                entity.ToTable("likeartist", "laboratories");

                entity.Property(e => e.Aname)
                    .HasColumnName("aname")
                    .HasMaxLength(20);

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.HasOne(d => d.AnameNavigation)
                    .WithMany(p => p.Likeartist)
                    .HasForeignKey(d => d.Aname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("likeartist_aname_fkey");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Likeartist)
                    .HasForeignKey(d => d.Custid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("likeartist_custid_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("person_pkey");

                entity.ToTable("person", "project");

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .ValueGeneratedNever();

                entity.Property(e => e.AptNumber).HasColumnName("apt_number");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PState)
                    .IsRequired()
                    .HasColumnName("p_state")
                    .HasMaxLength(50);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("street_name")
                    .HasMaxLength(50);

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Renting>(entity =>
            {
                entity.HasKey(e => e.Rentid)
                    .HasName("renting_pkey");

                entity.ToTable("renting", "project");

                entity.Property(e => e.Rentid)
                    .HasColumnName("rentid")
                    .HasDefaultValueSql("nextval('project.renting_rentid_seq'::regclass)");

                entity.Property(e => e.CustomerSsn).HasColumnName("customer_ssn");

                entity.Property(e => e.EmployeeSsn).HasColumnName("employee_ssn");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.HasOne(d => d.CustomerSsnNavigation)
                    .WithMany(p => p.Renting)
                    .HasForeignKey(d => d.CustomerSsn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_customer_fkey");

                entity.HasOne(d => d.EmployeeSsnNavigation)
                    .WithMany(p => p.Renting)
                    .HasForeignKey(d => d.EmployeeSsn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_employee_fkey");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Renting)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_room_fkey");
            });

            modelBuilder.Entity<Rentingarc>(entity =>
            {
                entity.HasKey(e => e.Rentaid)
                    .HasName("rentingarc_pkey");

                entity.ToTable("rentingarc", "project");

                entity.Property(e => e.Rentaid)
                    .HasColumnName("rentaid")
                    .HasDefaultValueSql("nextval('project.rentingarc_rentaid_seq'::regclass)");

                entity.Property(e => e.CustomerSsn).HasColumnName("customer_ssn");

                entity.Property(e => e.EmployeeSsn).HasColumnName("employee_ssn");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.StartDate).HasColumnName("start_date");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => new { e.Role1, e.EmployeeSsn })
                    .HasName("role_pkey");

                entity.ToTable("role", "project");

                entity.Property(e => e.Role1)
                    .HasColumnName("role")
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeSsn).HasColumnName("employee_ssn");

                entity.HasOne(d => d.EmployeeSsnNavigation)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.EmployeeSsn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_employee_fkey");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("room_pkey");

                entity.ToTable("room", "project");

                entity.Property(e => e.Rid)
                    .HasColumnName("rid")
                    .HasDefaultValueSql("nextval('project.room_rid_seq'::regclass)");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Hid).HasColumnName("hid");

                entity.Property(e => e.Isextandable).HasColumnName("isextandable");

                entity.Property(e => e.Landscape)
                    .IsRequired()
                    .HasColumnName("landscape")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.RoomNum).HasColumnName("room_num");

                entity.HasOne(d => d.H)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.Hid)
                    .HasConstraintName("room_hotel_fkey");
            });

            modelBuilder.HasSequence<int>("amenity_aid_seq");

            modelBuilder.HasSequence<int>("booking_bid_seq");

            modelBuilder.HasSequence<int>("bookingarc_baid_seq");

            modelBuilder.HasSequence<int>("damage_did_seq");

            modelBuilder.HasSequence<int>("hotel_hid_seq");

            modelBuilder.HasSequence<int>("hotelchain_hcid_seq");

            modelBuilder.HasSequence<int>("renting_rentid_seq");

            modelBuilder.HasSequence<int>("rentingarc_rentaid_seq");

            modelBuilder.HasSequence<int>("room_rid_seq");
        }
    }
}
