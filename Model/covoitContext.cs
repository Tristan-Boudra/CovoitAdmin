using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class covoitContext : DbContext
    {
        public covoitContext()
        {
        }

        public covoitContext(DbContextOptions<covoitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<EndPoint> EndPoint { get; set; }
        public virtual DbSet<Motorization> Motorization { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<Paths> Paths { get; set; }
        public virtual DbSet<StartingPoint> StartingPoint { get; set; }
        public virtual DbSet<Trips> Trips { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<VillesFranceFree> VillesFranceFree { get; set; }
        public object Posts { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=sql504.main-hosting.eu;port=3306;user=u154969661_covoit_erwan;password=3enNQ5rmF;database=u154969661_covoit");
            }
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.IdDriver)
                    .HasName("PRIMARY");

                entity.ToTable("driver");

                entity.HasIndex(e => e.IdTrip)
                    .HasName("constraint_trip2");

                entity.HasIndex(e => e.IdUser)
                    .HasName("constraint_user2");

                entity.HasIndex(e => e.IdVehicles)
                    .HasName("constraint_id_vehicles");

                entity.Property(e => e.IdDriver)
                    .HasColumnName("id_driver")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTrip)
                    .HasColumnName("id_trip")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVehicles)
                    .HasColumnName("id_vehicles")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_trip2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_user2");

                entity.HasOne(d => d.IdVehiclesNavigation)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.IdVehicles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_id_vehicles");
            });

            modelBuilder.Entity<EndPoint>(entity =>
            {
                entity.HasKey(e => e.IdEndPoint)
                    .HasName("PRIMARY");

                entity.ToTable("end_point");

                entity.HasIndex(e => e.IdCity)
                    .HasName("constraint_id_city_end_point2");

                entity.HasIndex(e => e.IdPath)
                    .HasName("constraint_path_id2");

                entity.Property(e => e.IdEndPoint)
                    .HasColumnName("id_end_point")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCity)
                    .HasColumnName("id_city")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPath)
                    .HasColumnName("id_path")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.EndPoint)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_id_city_end_point2");

                entity.HasOne(d => d.IdPathNavigation)
                    .WithMany(p => p.EndPoint)
                    .HasForeignKey(d => d.IdPath)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_path_id2");
            });

            modelBuilder.Entity<Motorization>(entity =>
            {
                entity.HasKey(e => e.IdMotorization)
                    .HasName("PRIMARY");

                entity.ToTable("motorization");

                entity.Property(e => e.IdMotorization)
                    .HasColumnName("id_motorization")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Libellet)
                    .IsRequired()
                    .HasColumnName("libellet")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.IdPassenger)
                    .HasName("PRIMARY");

                entity.ToTable("passenger");

                entity.HasIndex(e => e.IdPath)
                    .HasName("constraint_path");

                entity.HasIndex(e => e.IdUser)
                    .HasName("constraint_user");

                entity.Property(e => e.IdPassenger)
                    .HasColumnName("id_passenger")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPath)
                    .HasColumnName("id_path")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdPathNavigation)
                    .WithMany(p => p.Passenger)
                    .HasForeignKey(d => d.IdPath)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_path");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Passenger)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_user");
            });

            modelBuilder.Entity<Paths>(entity =>
            {
                entity.HasKey(e => e.IdPath)
                    .HasName("PRIMARY");

                entity.ToTable("paths");

                entity.HasIndex(e => e.IdTrip)
                    .HasName("constraint_trip");

                entity.Property(e => e.IdPath)
                    .HasColumnName("id_path")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartureTime).HasColumnName("departure_time");

                entity.Property(e => e.IdTrip)
                    .HasColumnName("id_trip")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.Paths)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_trip");
            });

            modelBuilder.Entity<StartingPoint>(entity =>
            {
                entity.HasKey(e => e.IdStartingPoint)
                    .HasName("PRIMARY");

                entity.ToTable("starting_point");

                entity.HasIndex(e => e.IdCity)
                    .HasName("constraint_id_city_starting_point");

                entity.HasIndex(e => e.IdPath)
                    .HasName("constraint_path_id");

                entity.Property(e => e.IdStartingPoint)
                    .HasColumnName("id_starting_point")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCity)
                    .HasColumnName("id_city")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPath)
                    .HasColumnName("id_path")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.StartingPoint)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_id_city_starting_point");

                entity.HasOne(d => d.IdPathNavigation)
                    .WithMany(p => p.StartingPoint)
                    .HasForeignKey(d => d.IdPath)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_path_id");
            });

            modelBuilder.Entity<Trips>(entity =>
            {
                entity.HasKey(e => e.IdTrip)
                    .HasName("PRIMARY");

                entity.ToTable("trips");

                entity.Property(e => e.IdTrip)
                    .HasColumnName("id_trip")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.StartingDate)
                    .HasColumnName("starting_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Administrator)
                    .HasColumnName("administrator")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Contacts)
                    .HasColumnName("contacts")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("f_name")
                    .HasMaxLength(30);

                entity.Property(e => e.ImgProfil)
                    .HasColumnName("img_profil")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasColumnName("l_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(200);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.IdVehicles)
                    .HasName("PRIMARY");

                entity.ToTable("vehicles");

                entity.HasIndex(e => e.IdMotorization)
                    .HasName("constraint_id_motorization");

                entity.HasIndex(e => e.IdUser)
                    .HasName("constraint_id_user");

                entity.Property(e => e.IdVehicles)
                    .HasColumnName("id_vehicles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(20);

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.IdMotorization)
                    .HasColumnName("id_motorization")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NbPlaces)
                    .HasColumnName("nb_places")
                    .HasColumnType("int(5)");

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasColumnName("vehicle_name")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdMotorizationNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.IdMotorization)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_id_motorization");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constraint_id_user");
            });

            modelBuilder.Entity<VillesFranceFree>(entity =>
            {
                entity.HasKey(e => e.VilleId)
                    .HasName("PRIMARY");

                entity.ToTable("villes_france_free");

                entity.HasIndex(e => e.VilleCodeCommune)
                    .HasName("ville_code_commune_2")
                    .IsUnique();

                entity.HasIndex(e => e.VilleCodePostal)
                    .HasName("ville_code_postal");

                entity.HasIndex(e => e.VilleDepartement)
                    .HasName("ville_departement");

                entity.HasIndex(e => e.VilleNom)
                    .HasName("ville_nom");

                entity.HasIndex(e => e.VilleNomMetaphone)
                    .HasName("ville_nom_metaphone");

                entity.HasIndex(e => e.VilleNomReel)
                    .HasName("ville_nom_reel");

                entity.HasIndex(e => e.VilleNomSimple)
                    .HasName("ville_nom_simple");

                entity.HasIndex(e => e.VilleNomSoundex)
                    .HasName("ville_nom_soundex");

                entity.HasIndex(e => e.VillePopulation2010)
                    .HasName("ville_population_2010");

                entity.HasIndex(e => e.VilleSlug)
                    .HasName("ville_slug")
                    .IsUnique();

                entity.HasIndex(e => new { e.VilleLongitudeDeg, e.VilleLatitudeDeg })
                    .HasName("ville_longitude_latitude_deg");

                entity.Property(e => e.VilleId)
                    .HasColumnName("ville_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VilleAmdi)
                    .HasColumnName("ville_amdi")
                    .HasColumnType("smallint(5) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleArrondissement)
                    .HasColumnName("ville_arrondissement")
                    .HasColumnType("smallint(3) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleCanton)
                    .HasColumnName("ville_canton")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleCodeCommune)
                    .IsRequired()
                    .HasColumnName("ville_code_commune")
                    .HasMaxLength(5);

                entity.Property(e => e.VilleCodePostal)
                    .HasColumnName("ville_code_postal")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleCommune)
                    .HasColumnName("ville_commune")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleDensite2010)
                    .HasColumnName("ville_densite_2010")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleDepartement)
                    .HasColumnName("ville_departement")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleLatitudeDeg)
                    .HasColumnName("ville_latitude_deg")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleLatitudeDms)
                    .HasColumnName("ville_latitude_dms")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleLatitudeGrd)
                    .HasColumnName("ville_latitude_grd")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleLongitudeDeg)
                    .HasColumnName("ville_longitude_deg")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleLongitudeDms)
                    .HasColumnName("ville_longitude_dms")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleLongitudeGrd)
                    .HasColumnName("ville_longitude_grd")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleNom)
                    .HasColumnName("ville_nom")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleNomMetaphone)
                    .HasColumnName("ville_nom_metaphone")
                    .HasMaxLength(22)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleNomReel)
                    .HasColumnName("ville_nom_reel")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleNomSimple)
                    .HasColumnName("ville_nom_simple")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleNomSoundex)
                    .HasColumnName("ville_nom_soundex")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VillePopulation1999)
                    .HasColumnName("ville_population_1999")
                    .HasColumnType("mediumint(11) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VillePopulation2010)
                    .HasColumnName("ville_population_2010")
                    .HasColumnType("mediumint(11) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VillePopulation2012)
                    .HasColumnName("ville_population_2012")
                    .HasColumnType("mediumint(10) unsigned")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("approximatif");

                entity.Property(e => e.VilleSlug)
                    .HasColumnName("ville_slug")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleSurface)
                    .HasColumnName("ville_surface")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleZmax)
                    .HasColumnName("ville_zmax")
                    .HasColumnType("mediumint(4)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VilleZmin)
                    .HasColumnName("ville_zmin")
                    .HasColumnType("mediumint(4)")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
