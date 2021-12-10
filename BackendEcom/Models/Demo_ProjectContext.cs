using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class Demo_ProjectContext : DbContext
    {
        public Demo_ProjectContext()
        {
        }

        public Demo_ProjectContext(DbContextOptions<Demo_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryMetadataField> CategoryMetadataField { get; set; }
        public virtual DbSet<CategoryMetadataFieldValues> CategoryMetadataFieldValues { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderTable> OrderTable { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductVariation> ProductVariation { get; set; }
        public virtual DbSet<RoleTable> RoleTable { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-26JC778; Database=Demo_Project; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Label)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ZipCode).HasColumnName("Zip_Code");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Addresses__UserI__2B3F6F97");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CART");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.IsWishlistItem)
                    .HasColumnName("IS_WISHLIST_ITEM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CART__CustomerID__5DCAEF64");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany()
                    .HasForeignKey(d => d.ProductVariationId)
                    .HasConstraintName("FK__CART__ProductVar__5FB337D6");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Category__Produc__412EB0B6");
            });

            modelBuilder.Entity<CategoryMetadataField>(entity =>
            {
                entity.ToTable("CATEGORY_METADATA_FIELD");

                entity.Property(e => e.CategoryMetadataFieldId)
                    .HasColumnName("CategoryMetadataFieldID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryFieldname)
                    .IsRequired()
                    .HasColumnName("CategoryFIELDName")
                    .HasMaxLength(4000);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryMetadataFieldValues>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CATEGORY_METADATA_FIELD_VALUES");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryMetadataFieldId).HasColumnName("CategoryMetadataFieldID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Values)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__CATEGORY___Categ__48CFD27E");

                entity.HasOne(d => d.CategoryMetadataField)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryMetadataFieldId)
                    .HasConstraintName("FK__CATEGORY___Categ__47DBAE45");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerContact)
                    .HasName("PK__Customer__BB5D1785D38E3872");

                entity.Property(e => e.CustomerContact)
                    .HasColumnName("Customer_Contact")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Customer__UserID__08B54D69");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.Property(e => e.OrderProductId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderProd__Order__571DF1D5");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.ProductVariationId)
                    .HasConstraintName("FK__OrderProd__Produ__5812160E");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FromStatus)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ToStatus).HasColumnType("date");

                entity.Property(e => e.TransitionNotesComments)
                    .HasColumnName("TRANSITION_NOTES_COMMENTS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderProduct)
                    .WithMany()
                    .HasForeignKey(d => d.OrderProductId)
                    .HasConstraintName("FK__OrderStat__Order__5AEE82B9");
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderTab__C3905BCF0B7D428F");

                entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AmountPaid)
                    .HasColumnName("Amount_Paid")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("Date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.OrderTable)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__OrderTabl__Addre__52593CB8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderTable)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__OrderTabl__Custo__5165187F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsCancelable)
                    .HasColumnName("Is_Cancelable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsReturnable)
                    .HasColumnName("Is_Returnable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.PDescription)
                    .IsRequired()
                    .HasColumnName("P_Description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PName)
                    .IsRequired()
                    .HasColumnName("P_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Sellerid)
                    .HasConstraintName("FK__Product__Selleri__35BCFE0A");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_Review");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerUserId).HasColumnName("Customer_User_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Review)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerUser)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerUserId)
                    .HasConstraintName("FK__Product_R__Custo__4BAC3F29");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Product_R__Produ__4CA06362");
            });

            modelBuilder.Entity<ProductVariation>(entity =>
            {
                entity.ToTable("Product_Variation");

                entity.Property(e => e.ProductVariationId)
                    .HasColumnName("ProductVariationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.PrimaryImageName)
                    .HasColumnName("Primary_Image_Name")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.QunatityAvailable).HasColumnName("Qunatity_Available");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VariationMetadata)
                    .HasColumnName("Variation_Metadata")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariation)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Product_V__Produ__3D5E1FD2");
            });

            modelBuilder.Entity<RoleTable>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleTabl__8AFACE3A1B88AA7B");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Authority)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.CompanyContact)
                    .HasName("PK__Seller__0713D0CDFB5DDBA0");

                entity.Property(e => e.CompanyContact)
                    .HasColumnName("Company_Contact")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Gst)
                    .IsRequired()
                    .HasColumnName("GST")
                    .HasMaxLength(15);

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.SellerNavigation)
                    .WithMany(p => p.Seller)
                    .HasForeignKey(d => d.Sellerid)
                    .HasConstraintName("FK__Seller__Sellerid__03F0984C");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRole__RoleID__656C112C");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRole__UserID__6477ECF3");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("date");

                entity.Property(e => e.Upassword)
                    .IsRequired()
                    .HasColumnName("UPassword");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
