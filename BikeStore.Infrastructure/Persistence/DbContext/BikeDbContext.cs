using System;
using System.Collections.Generic;
using BikeStore.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Infrastructure.Persistence.DbContext;

public partial class BikeDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public BikeDbContext()
    {
    }

    public BikeDbContext(DbContextOptions<BikeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Category1> Categories1 { get; set; }

    public virtual DbSet<CategoryStaging> CategoryStagings { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductHistory> ProductHistories { get; set; }

    public virtual DbSet<ProductJson> ProductJsons { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<SalesSummary> SalesSummaries { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Target> Targets { get; set; }

    public virtual DbSet<Taxis> Taxes { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:bike_store_db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__addresse__CAA247C83808287B");

            entity.ToTable("addresses", "sales");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("zipcode");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E272F8B6B51");

            entity.ToTable("brands", "production");

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__candidat__3213E83FC6B30D96");

            entity.ToTable("candidates", "hr");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fullname");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B43ACFB98A");

            entity.ToTable("categories", "production");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Category1>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B4DB926F07");

            entity.ToTable("category", "sales");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("category_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<CategoryStaging>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B406ADC40F");

            entity.ToTable("category_staging", "sales");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("category_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Commission>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__commissi__1963DD9C4C878DBC");

            entity.ToTable("commissions", "sales");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("staff_id");
            entity.Property(e => e.BaseAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("base_amount");
            entity.Property(e => e.Commission1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("commission");
            entity.Property(e => e.TargetId).HasColumnName("target_id");

            entity.HasOne(d => d.Staff).WithOne(p => p.Commission)
                .HasForeignKey<Commission>(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__commissio__staff__08B54D69");

            entity.HasOne(d => d.Target).WithMany(p => p.Commissions)
                .HasForeignKey(d => d.TargetId)
                .HasConstraintName("FK__commissio__targe__07C12930");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__companie__3213E83F4FA55F23");

            entity.ToTable("companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB85F9F9F759");

            entity.ToTable("customers", "sales");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<CustomerGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__customer__D57795A091B0129E");

            entity.ToTable("customer_groups", "sales");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("group_name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F9DC9560A");

            entity.ToTable("employees", "hr");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fullname");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__feedback__7A6B2B8C6894CFD2");

            entity.ToTable("feedbacks", "sales");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comment");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__invoices__3213E83F5233C91E");

            entity.ToTable("invoices");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 1)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.InvoiceId }).HasName("PK__invoice___BD4B37EBA5E977A4");

            entity.ToTable("invoice_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.Tax)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("tax");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__invoice_i__invoi__1F98B2C1");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__jobs__6E32B6A588953090");

            entity.ToTable("jobs", "customer_services");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__members__3213E83F6D082288");

            entity.ToTable("members", "pm");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.Project).WithMany(p => p.Members)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__members__project__5CD6CB2B");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.OfficeId).HasName("PK__offices__2A196375D6A83518");

            entity.ToTable("offices", "sales");

            entity.Property(e => e.OfficeId).HasColumnName("office_id");
            entity.Property(e => e.OfficeAddress)
                .HasMaxLength(255)
                .HasColumnName("office_address");
            entity.Property(e => e.OfficeName)
                .HasMaxLength(40)
                .HasColumnName("office_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__465962294879AD05");

            entity.ToTable("orders", "sales");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.RequiredDate).HasColumnName("required_date");
            entity.Property(e => e.ShippedDate).HasColumnName("shipped_date");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__orders__customer__47DBAE45");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__staff_id__49C3F6B7");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__orders__store_id__48CFD27E");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D4E502891E");

            entity.ToTable("order_items", "sales");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ListPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("list_price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__order_ite__order__4D94879B");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__order_ite__produ__4E88ABD4");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__person__543848DF098A5CD1");

            entity.ToTable("person", "hr");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");

            entity.HasMany(d => d.Positions).WithMany(p => p.People)
                .UsingEntity<Dictionary<string, object>>(
                    "PersonPosition",
                    r => r.HasOne<Position>().WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__person_po__posit__395884C4"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__person_po__perso__3864608B"),
                    j =>
                    {
                        j.HasKey("PersonId", "PositionId").HasName("PK__person_p__0DA246A59D3BA045");
                        j.ToTable("person_position", "hr");
                        j.IndexerProperty<int>("PersonId").HasColumnName("person_id");
                        j.IndexerProperty<int>("PositionId").HasColumnName("position_id");
                    });
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__position__99A0E7A4FA19732A");

            entity.ToTable("position", "hr");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("position_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF501675EE2");

            entity.ToTable("products", "production");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ListPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("list_price");
            entity.Property(e => e.ModelYear).HasColumnName("model_year");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__products__brand___3C69FB99");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__products__catego__3B75D760");
        });

        modelBuilder.Entity<ProductHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_history", "production");

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ListPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("list_price");
            entity.Property(e => e.ModelYear).HasColumnName("model_year");
            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");
        });

        modelBuilder.Entity<ProductJson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83FBEE12079");

            entity.ToTable("product_json");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Info).HasColumnName("info");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F7E7DE710");

            entity.ToTable("projects", "pm");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__promotio__2CB9556BD891C187");

            entity.ToTable("promotions", "sales");

            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(3, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ExpiredDate).HasColumnName("expired_date");
            entity.Property(e => e.PromotionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("promotion_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.QuotationNo).HasName("PK__quotatio__78413F48CAC949F1");

            entity.ToTable("quotations", "sales");

            entity.Property(e => e.QuotationNo).HasColumnName("quotation_no");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
            entity.Property(e => e.ValidTo).HasColumnName("valid_to");
        });

        modelBuilder.Entity<SalesSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sales_summary", "sales");

            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.ModelYear).HasColumnName("model_year");
            entity.Property(e => e.Sales)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("sales");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9CA0A9EA28");

            entity.ToTable("staffs", "sales");

            entity.HasIndex(e => e.Email, "UQ__staffs__AB6E6164F86F69A9").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__staffs__manager___44FF419A");

            entity.HasOne(d => d.Store).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__staffs__store_id__440B1D61");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D3991617BE");

            entity.ToTable("stocks", "production");

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__stocks__product___52593CB8");

            entity.HasOne(d => d.Store).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__stocks__store_id__5165187F");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30C0574F52F");

            entity.ToTable("stores", "sales");

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.StoreName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("store_name");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<Target>(entity =>
        {
            entity.HasKey(e => e.TargetId).HasName("PK__targets__57D3816E67487F6B");

            entity.ToTable("targets", "sales");

            entity.Property(e => e.TargetId)
                .ValueGeneratedNever()
                .HasColumnName("target_id");
            entity.Property(e => e.Percentage)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("percentage");
        });

        modelBuilder.Entity<Taxis>(entity =>
        {
            entity.HasKey(e => e.TaxId).HasName("PK__taxes__129B867022976689");

            entity.ToTable("taxes", "sales");

            entity.HasIndex(e => e.State, "UQ__taxes__A9360BC393EF4569").IsUnique();

            entity.Property(e => e.TaxId).HasColumnName("tax_id");
            entity.Property(e => e.AvgLocalTaxRate)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("avg_local_tax_rate");
            entity.Property(e => e.CombinedRate)
                .HasComputedColumnSql("([state_tax_rate]+[avg_local_tax_rate])", false)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("combined_rate");
            entity.Property(e => e.MaxLocalTaxRate)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("max_local_tax_rate");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.StateTaxRate)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("state_tax_rate");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__visits__375A75E18BB37FE3");

            entity.ToTable("visits", "sales");

            entity.Property(e => e.VisitId).HasColumnName("visit_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.VisitedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("visited_at");

            entity.HasOne(d => d.Store).WithMany(p => p.Visits)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__visits__store_id__30C33EC3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
