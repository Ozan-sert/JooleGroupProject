namespace JooleGroupProject.RepositoryLayer.Migrations
{
    using JooleGroupProject.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Attribute = DAL.Models.Attribute;

    internal sealed class Configuration : DbMigrationsConfiguration<JooleGroupProject.RepositoryLayer.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JooleGroupProject.RepositoryLayer.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var categories = new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Mechanical" },
                new Category { CategoryID = 2, CategoryName = "Electrical" },
                new Category { CategoryID = 3, CategoryName = "Stationary" },
                new Category { CategoryID = 4, CategoryName = "Furniture" },
            };

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(c => c.CategoryID, category);
            }

            var subCategories = new List<SubCategory>
            {
                //Mechanical
                new SubCategory { SubCategoryID = 1, CategoryID = 1, SubCategoryName = "Fans" },
                new SubCategory { SubCategoryID = 2, CategoryID = 1, SubCategoryName = "Vacuums" },
                new SubCategory { SubCategoryID = 3, CategoryID = 1, SubCategoryName = "Toasters" },

                //Electrical
                new SubCategory { SubCategoryID = 4, CategoryID = 2, SubCategoryName = "Refrigerators" },
                new SubCategory { SubCategoryID = 5, CategoryID = 2, SubCategoryName = "Ovens" },

                //Stationary
                new SubCategory { SubCategoryID = 6, CategoryID = 3, SubCategoryName = "Notebooks" },
                new SubCategory { SubCategoryID = 7, CategoryID = 3, SubCategoryName = "Pens" },


                //Furniture
                new SubCategory { SubCategoryID = 8, CategoryID = 4, SubCategoryName = "Chairs" },
                new SubCategory { SubCategoryID = 9, CategoryID = 4, SubCategoryName = "Desks" },
            };

            foreach (var subCategory in subCategories)
            {
                context.SubCategories.AddOrUpdate(subCategory);
            }

            var products = new List<Product>
            {
                // Products for "Fans"
                new Product { ProductID = 1, SubCategoryID = 1, ProductName = "Ceiling Fan", Model = "CF100", Manufacturer = "CoolingCo", ModelYear = 2020, Series = "Elite" },
                new Product { ProductID = 2, SubCategoryID = 1, ProductName = "Table Fan", Model = "TF200", Manufacturer = "BreezyCo", ModelYear = 2021, Series = "Compact" },
                new Product { ProductID = 3, SubCategoryID = 1, ProductName = "Retro Table Fan", Model = "RTF1950", Manufacturer = "OldStyleCo", ModelYear = 1950, Series = "Retro" },
                new Product { ProductID = 4, SubCategoryID = 1, ProductName = "High Velocity Floor Fan", Model = "HVFF1985", Manufacturer = "StrongBreezeCo", ModelYear = 1985, Series = "High Speed" },
                new Product { ProductID = 5, SubCategoryID = 1, ProductName = "Silent Tower Fan", Model = "STF2000", Manufacturer = "QuietCoolCo", ModelYear = 2000, Series = "Silent" },
                new Product { ProductID = 6, SubCategoryID = 1, ProductName = "Smart Ceiling Fan", Model = "SCF2023", Manufacturer = "FutureCoolCo", ModelYear = 2023, Series = "Smart Home" },

                // Products for "Vacuums"
                new Product { ProductID = 7, SubCategoryID = 2, ProductName = "Handheld Vacuum", Model = "HV300", Manufacturer = "CleanCo", ModelYear = 2020, Series = "Handy" },
                new Product { ProductID = 8, SubCategoryID = 2, ProductName = "Robot Vacuum", Model = "RV400", Manufacturer = "SmartCleanCo", ModelYear = 2022, Series = "Smart" },

                // Products for "Toasters"
                new Product { ProductID = 9, SubCategoryID = 3, ProductName = "2-Slice Toaster", Model = "2ST500", Manufacturer = "ToastCo", ModelYear = 2020, Series = "Quick" },
                new Product { ProductID = 10, SubCategoryID = 3, ProductName = "4-Slice Toaster", Model = "4ST600", Manufacturer = "ToastMasterCo", ModelYear = 2021, Series = "Family" },

                // Products for "Refrigerators"
                new Product { ProductID = 11, SubCategoryID = 4, ProductName = "Single-Door Refrigerator", Model = "SDR700", Manufacturer = "CoolStorageCo", ModelYear = 2020, Series = "Compact" },
                new Product { ProductID = 12, SubCategoryID = 4, ProductName = "Double-Door Refrigerator", Model = "DDR800", Manufacturer = "ColdKeeperCo", ModelYear = 2021, Series = "Spacious" },

                // Products for "Ovens"
                new Product { ProductID = 13, SubCategoryID = 5, ProductName = "Microwave Oven", Model = "MO900", Manufacturer = "HeatCo", ModelYear = 2020, Series = "Quick" },
                new Product { ProductID = 14, SubCategoryID = 5, ProductName = "Convection Oven", Model = "CO1000", Manufacturer = "BakeCo", ModelYear = 2021, Series = "Bake" },

                // Products for "Notebooks"
                new Product { ProductID = 15, SubCategoryID = 6, ProductName = "Lined Notebook", Model = "LN1100", Manufacturer = "WriteCo", ModelYear = 2020, Series = "Standard" },
                new Product { ProductID = 16, SubCategoryID = 6, ProductName = "Graph Notebook", Model = "GN1200", Manufacturer = "GraphCo", ModelYear = 2021, Series = "Graph" },

                // Products for "Pens"
                new Product { ProductID = 17, SubCategoryID = 7, ProductName = "Ballpoint Pen", Model = "BP1300", Manufacturer = "WriteCo", ModelYear = 2020, Series = "Standard" },
                new Product { ProductID = 18, SubCategoryID = 7, ProductName = "Fountain Pen", Model = "FP1400", Manufacturer = "WriteCo", ModelYear = 2021, Series = "Fountain" },

                // Products for "Chairs"
                new Product { ProductID = 19, SubCategoryID = 8, ProductName = "Office Chair", Model = "OC1500", Manufacturer = "SitCo", ModelYear = 2020, Series = "Standard" },
                new Product { ProductID = 20, SubCategoryID = 8, ProductName = "Dining Chair", Model = "DC1600", Manufacturer = "SitCo", ModelYear = 2021, Series = "Dining" },
                new Product { ProductID = 21, SubCategoryID = 8, ProductName = "Recliner Chair", Model = "RC1700", Manufacturer = "OfficeCo", ModelYear = 2022, Series = "Recliner" },

                // Products for "Desks"
                new Product { ProductID = 22, SubCategoryID = 9, ProductName = "Writing Desk", Model = "WD1700", Manufacturer = "StableTableCo", ModelYear = 2021, Series = "Scribe" },
                new Product { ProductID = 23, SubCategoryID = 9, ProductName = "Computer Desk", Model = "CD1800", Manufacturer = "WorkspaceCo", ModelYear = 2022, Series = "Techie" },
            };

            foreach (var product in products)
            {
                context.Products.AddOrUpdate(product);
            }

            var attributes = new List<Attribute>
            {

                // Fans Attributes
                new Attribute { AttributeID = 1, AttributeName = "Use Type", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 2, AttributeName = "Application", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 3, AttributeName = "Mounting Location", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 4, AttributeName = "Accessories", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 5, AttributeName = "Air Flow(CFM)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 6, AttributeName = "Power(W)_Min", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 7, AttributeName = "Power(W)_Max", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 8, AttributeName = "Operating Voltage(VAC)_Min", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 9, AttributeName = "Operating Voltage(VAC)_Max", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 10, AttributeName = "Fan Speed(RPM)_Min", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 11, AttributeName = "Fan Speed(RPM)_Max", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 12, AttributeName = "Number of Fan Speeds", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 13, AttributeName = "Sound at Max Speed(dBA)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 14, AttributeName = "Fan Sweep Diameter(in)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 15, AttributeName = "Height(in)_Min", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 16, AttributeName = "Height(in)_Max", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 17, AttributeName = "Weight(lbs)", IsTechSpec = true, IsType = false },

                // Vacuums Attributes
                new Attribute { AttributeID = 18, AttributeName = "Bagged/Bagless", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 19, AttributeName = "Bin Capacity(liters)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 20, AttributeName = "Suction Power(AW)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 22, AttributeName = "Cordless/Corded", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 23, AttributeName = "Battery Voltage(V)", IsTechSpec = true, IsType = false },

                // Toasters Attributes
                new Attribute { AttributeID = 24, AttributeName = "Slice Capacity", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 25, AttributeName = "Toasting Levels", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 26, AttributeName = "Power(W)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 27, AttributeName = "Bagel Setting", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 28, AttributeName = "Defrost Function", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 29, AttributeName = "Crumb Tray", IsTechSpec = false, IsType = true },

                // Refrigerators Attributes
                new Attribute { AttributeID = 30, AttributeName = "Door Style", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 31, AttributeName = "Total Capacity(cu. ft.)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 32, AttributeName = "Freezer Capacity(cu. ft.)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 34, AttributeName = "Energy Star Certified", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 35, AttributeName = "Ice Maker", IsTechSpec = false, IsType = true },

                // Ovens Attributes
                new Attribute { AttributeID = 36, AttributeName = "Fuel Type", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 37, AttributeName = "Oven Capacity(cu. ft.)", IsTechSpec = true, IsType = false },
                // 
                new Attribute { AttributeID = 39, AttributeName = "Self Cleaning", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 40, AttributeName = "Convection", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 41, AttributeName = "Number of Oven Racks", IsTechSpec = true, IsType = false },

                // Notebooks Attributes
                new Attribute { AttributeID = 42, AttributeName = "Page Layout", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 43, AttributeName = "Page Count", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 44, AttributeName = "Paper Weight(gsm)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 45, AttributeName = "Cover Material", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 46, AttributeName = "Binding", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 47, AttributeName = "Line Spacing(mm)", IsTechSpec = true, IsType = false },

                // Pens Attributes
                new Attribute { AttributeID = 48, AttributeName = "Ink Color", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 49, AttributeName = "Ink Type", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 50, AttributeName = "Line Width(mm)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 51, AttributeName = "Retractable", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 52, AttributeName = "Grip Type", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 53, AttributeName = "Material", IsTechSpec = false, IsType = true },

                // Chairs Attributes
                //
                new Attribute { AttributeID = 55, AttributeName = "Max Weight Capacity(lbs)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 57, AttributeName = "Chair Type", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 58, AttributeName = "Adjustable Height", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 59, AttributeName = "Armrest", IsTechSpec = false, IsType = true },

                // Desks Attributes
                //
                new Attribute { AttributeID = 61, AttributeName = "Desk Type", IsTechSpec = false, IsType = true },
                new Attribute { AttributeID = 62, AttributeName = "Width(in)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 63, AttributeName = "Depth(in)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 64, AttributeName = "Height(in)", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 65, AttributeName = "Number of Drawers", IsTechSpec = true, IsType = false },
                new Attribute { AttributeID = 66, AttributeName = "Adjustable Height", IsTechSpec = false, IsType = true },
            };

            foreach (var attribute in attributes)
            {
                context.Attributes.AddOrUpdate(attribute);
            }


            var productAttributes = new List<ProductAttribute>
            {
                //Ceiling Fan
                new ProductAttribute { ProductID = 1, AttributeID = 1, AttributeValue = "Indoor" },
                new ProductAttribute { ProductID = 1, AttributeID = 2, AttributeValue = "Residential" },
                new ProductAttribute { ProductID = 1, AttributeID = 3, AttributeValue = "Ceiling" },
                new ProductAttribute { ProductID = 1, AttributeID = 4, AttributeValue = "Remote Control" },
                new ProductAttribute { ProductID = 1, AttributeID = 5, AttributeValue = "6500" }, // CFM
                new ProductAttribute { ProductID = 1, AttributeID = 6, AttributeValue = "15" }, // Power Min
                new ProductAttribute { ProductID = 1, AttributeID = 7, AttributeValue = "60" }, // Power Max
                new ProductAttribute { ProductID = 1, AttributeID = 8, AttributeValue = "110" }, // Operating Voltage Min
                new ProductAttribute { ProductID = 1, AttributeID = 9, AttributeValue = "220" }, // Operating Voltage Max
                new ProductAttribute { ProductID = 1, AttributeID = 10, AttributeValue = "800" }, // Fan Speed Min
                new ProductAttribute { ProductID = 1, AttributeID = 11, AttributeValue = "1800" }, // Fan Speed Max
                new ProductAttribute { ProductID = 1, AttributeID = 12, AttributeValue = "3" }, // Number of Fan Speeds
                new ProductAttribute { ProductID = 1, AttributeID = 13, AttributeValue = "50" }, // Sound at Max Speed
                new ProductAttribute { ProductID = 1, AttributeID = 14, AttributeValue = "52" }, // Fan Sweep Diameter
                new ProductAttribute { ProductID = 1, AttributeID = 15, AttributeValue = "12" }, // Height Min
                new ProductAttribute { ProductID = 1, AttributeID = 16, AttributeValue = "12" }, // Height Max
                new ProductAttribute { ProductID = 1, AttributeID = 17, AttributeValue = "20" }, // Weight

                // Table Fan
                new ProductAttribute { ProductID = 2, AttributeID = 1, AttributeValue = "Indoor" },
                new ProductAttribute { ProductID = 2, AttributeID = 2, AttributeValue = "Residential" },
                new ProductAttribute { ProductID = 2, AttributeID = 3, AttributeValue = "Tabletop" },
                new ProductAttribute { ProductID = 2, AttributeID = 4, AttributeValue = "Base" },
                new ProductAttribute { ProductID = 2, AttributeID = 5, AttributeValue = "2000" }, // CFM
                new ProductAttribute { ProductID = 2, AttributeID = 6, AttributeValue = "10" }, // Power Min
                new ProductAttribute { ProductID = 2, AttributeID = 7, AttributeValue = "40" }, // Power Max
                new ProductAttribute { ProductID = 2, AttributeID = 8, AttributeValue = "110" }, // Operating Voltage Min
                new ProductAttribute { ProductID = 2, AttributeID = 9, AttributeValue = "220" }, // Operating Voltage Max
                new ProductAttribute { ProductID = 2, AttributeID = 10, AttributeValue = "500" }, // Fan Speed Min
                new ProductAttribute { ProductID = 2, AttributeID = 11, AttributeValue = "1300" }, // Fan Speed Max
                new ProductAttribute { ProductID = 2, AttributeID = 12, AttributeValue = "3" }, // Number of Fan Speeds
                new ProductAttribute { ProductID = 2, AttributeID = 13, AttributeValue = "40" }, // Sound at Max Speed
                new ProductAttribute { ProductID = 2, AttributeID = 14, AttributeValue = "16" }, // Fan Sweep Diameter
                new ProductAttribute { ProductID = 2, AttributeID = 15, AttributeValue = "8" }, // Height Min
                new ProductAttribute { ProductID = 2, AttributeID = 16, AttributeValue = "8" }, // Height Max
                new ProductAttribute { ProductID = 2, AttributeID = 17, AttributeValue = "6" }, // Weight

                // Retro Table Fan
                new ProductAttribute { ProductID = 3, AttributeID = 1, AttributeValue = "Indoor" },
                new ProductAttribute { ProductID = 3, AttributeID = 2, AttributeValue = "Commercial" },
                new ProductAttribute { ProductID = 3, AttributeID = 3, AttributeValue = "Tabletop" },
                new ProductAttribute { ProductID = 3, AttributeID = 4, AttributeValue = "Base" },
                new ProductAttribute { ProductID = 3, AttributeID = 5, AttributeValue = "1800" }, // CFM
                new ProductAttribute { ProductID = 3, AttributeID = 6, AttributeValue = "12" }, // Power Min
                new ProductAttribute { ProductID = 3, AttributeID = 7, AttributeValue = "45" }, // Power Max
                new ProductAttribute { ProductID = 3, AttributeID = 8, AttributeValue = "110" }, // Operating Voltage Min
                new ProductAttribute { ProductID = 3, AttributeID = 9, AttributeValue = "220" }, // Operating Voltage Max
                new ProductAttribute { ProductID = 3, AttributeID = 10, AttributeValue = "600" }, // Fan Speed Min
                new ProductAttribute { ProductID = 3, AttributeID = 11, AttributeValue = "1500" }, // Fan Speed Max
                new ProductAttribute { ProductID = 3, AttributeID = 12, AttributeValue = "3" }, // Number of Fan Speeds
                new ProductAttribute { ProductID = 3, AttributeID = 13, AttributeValue = "45" }, // Sound at Max Speed
                new ProductAttribute { ProductID = 3, AttributeID = 14, AttributeValue = "14" }, // Fan Sweep Diameter
                new ProductAttribute { ProductID = 3, AttributeID = 15, AttributeValue = "7" }, // Height Min
                new ProductAttribute { ProductID = 3, AttributeID = 16, AttributeValue = "7" }, // Height Max
                new ProductAttribute { ProductID = 3, AttributeID = 17, AttributeValue = "5" }, // Weight

                // High Velocity Floor Fan
                new ProductAttribute { ProductID = 4, AttributeID = 1, AttributeValue = "Outdoor" },
                new ProductAttribute { ProductID = 4, AttributeID = 2, AttributeValue = "Commercial" },
                new ProductAttribute { ProductID = 4, AttributeID = 3, AttributeValue = "Floor" },
                new ProductAttribute { ProductID = 4, AttributeID = 4, AttributeValue = "Base" },
                new ProductAttribute { ProductID = 4, AttributeID = 5, AttributeValue = "5000" }, // CFM
                new ProductAttribute { ProductID = 4, AttributeID = 6, AttributeValue = "50" }, // Power Min
                new ProductAttribute { ProductID = 4, AttributeID = 7, AttributeValue = "200" }, // Power Max
                new ProductAttribute { ProductID = 4, AttributeID = 8, AttributeValue = "110" }, // Operating Voltage Min
                new ProductAttribute { ProductID = 4, AttributeID = 9, AttributeValue = "220" }, // Operating Voltage Max
                new ProductAttribute { ProductID = 4, AttributeID = 10, AttributeValue = "800" }, // Fan Speed Min
                new ProductAttribute { ProductID = 4, AttributeID = 11, AttributeValue = "3000" }, // Fan Speed Max
                new ProductAttribute { ProductID = 4, AttributeID = 12, AttributeValue = "4" }, // Number of Fan Speeds
                new ProductAttribute { ProductID = 4, AttributeID = 13, AttributeValue = "60" }, // Sound at Max Speed
                new ProductAttribute { ProductID = 4, AttributeID = 14, AttributeValue = "20" }, // Fan Sweep Diameter
                new ProductAttribute { ProductID = 4, AttributeID = 15, AttributeValue = "9" }, // Height Min
                new ProductAttribute { ProductID = 4, AttributeID = 16, AttributeValue = "9" }, // Height Max
                new ProductAttribute { ProductID = 4, AttributeID = 17, AttributeValue = "10" }, // Weight

                // Silent Tower Fan
                new ProductAttribute { ProductID = 5, AttributeID = 1, AttributeValue = "Indoor" },
                new ProductAttribute { ProductID = 5, AttributeID = 2, AttributeValue = "Residential" },
                new ProductAttribute { ProductID = 5, AttributeID = 3, AttributeValue = "Floor" },
                new ProductAttribute { ProductID = 5, AttributeID = 4, AttributeValue = "Base" },
                new ProductAttribute { ProductID = 5, AttributeID = 5, AttributeValue = "2500" }, // CFM
                new ProductAttribute { ProductID = 5, AttributeID = 6, AttributeValue = "20" }, // Power Min
                new ProductAttribute { ProductID = 5, AttributeID = 7, AttributeValue = "80" }, // Power Max
                new ProductAttribute { ProductID = 5, AttributeID = 8, AttributeValue = "110" }, // Operating Voltage Min
                new ProductAttribute { ProductID = 5, AttributeID = 9, AttributeValue = "220" }, // Operating Voltage Max
                new ProductAttribute { ProductID = 5, AttributeID = 10, AttributeValue = "700" }, // Fan Speed Min
                new ProductAttribute { ProductID = 5, AttributeID = 11, AttributeValue = "1800" }, // Fan Speed Max
                new ProductAttribute { ProductID = 5, AttributeID = 12, AttributeValue = "3" }, // Number of Fan Speeds
                new ProductAttribute { ProductID = 5, AttributeID = 13, AttributeValue = "35" }, // Sound at Max Speed
                new ProductAttribute { ProductID = 5, AttributeID = 14, AttributeValue = "32" }, // Fan Sweep Diameter
                new ProductAttribute { ProductID = 5, AttributeID = 15, AttributeValue = "40" }, // Height Min
                new ProductAttribute { ProductID = 5, AttributeID = 16, AttributeValue = "40" }, // Height Max
                new ProductAttribute { ProductID = 5, AttributeID = 17, AttributeValue = "12" }, // Weight

                // Smart Ceiling Fan
                new ProductAttribute { ProductID = 6, AttributeID = 1, AttributeValue = "Indoor" },
                new ProductAttribute { ProductID = 6, AttributeID = 2, AttributeValue = "Residential" },
                new ProductAttribute { ProductID = 6, AttributeID = 3, AttributeValue = "Ceiling" },
                new ProductAttribute { ProductID = 6, AttributeID = 4, AttributeValue = "Remote Control" },
                new ProductAttribute { ProductID = 6, AttributeID = 5, AttributeValue = "4500" }, // CFM
                new ProductAttribute { ProductID = 6, AttributeID = 6, AttributeValue = "25" }, // Power Min
                new ProductAttribute { ProductID = 6, AttributeID = 7, AttributeValue = "75" }, // Power Max
                new ProductAttribute { ProductID = 6, AttributeID = 8, AttributeValue = "110" }, // Operating Voltage Min
                new ProductAttribute { ProductID = 6, AttributeID = 9, AttributeValue = "220" }, // Operating Voltage Max
                new ProductAttribute { ProductID = 6, AttributeID = 10, AttributeValue = "700" }, // Fan Speed Min
                new ProductAttribute { ProductID = 6, AttributeID = 11, AttributeValue = "1800" }, // Fan Speed Max
                new ProductAttribute { ProductID = 6, AttributeID = 12, AttributeValue = "5" }, // Number of Fan Speeds
                new ProductAttribute { ProductID = 6, AttributeID = 13, AttributeValue = "40" }, // Sound at Max Speed
                new ProductAttribute { ProductID = 6, AttributeID = 14, AttributeValue = "52" }, // Fan Sweep Diameter
                new ProductAttribute { ProductID = 6, AttributeID = 15, AttributeValue = "12" }, // Height Min
                new ProductAttribute { ProductID = 6, AttributeID = 16, AttributeValue = "12" }, // Height Max
                new ProductAttribute { ProductID = 6, AttributeID = 17, AttributeValue = "20" }, // Weight

                // Handheld Vacuum
                new ProductAttribute { ProductID = 7, AttributeID = 18, AttributeValue = "Bagless" },
                new ProductAttribute { ProductID = 7, AttributeID = 19, AttributeValue = "0.5" }, // Bin Capacity(liters)
                new ProductAttribute { ProductID = 7, AttributeID = 20, AttributeValue = "110" }, // Suction Power(AW)
                new ProductAttribute { ProductID = 7, AttributeID = 17, AttributeValue = "3.8" }, // Weight
                new ProductAttribute { ProductID = 7, AttributeID = 22, AttributeValue = "Cordless" },
                new ProductAttribute { ProductID = 7, AttributeID = 23, AttributeValue = "20" }, // Battery Voltage

                // Robot Vacuum
                new ProductAttribute { ProductID = 8, AttributeID = 18, AttributeValue = "Bagless" },
                new ProductAttribute { ProductID = 8, AttributeID = 19, AttributeValue = "0.7" }, // Bin Capacity(liters)
                new ProductAttribute { ProductID = 8, AttributeID = 20, AttributeValue = "220 AW" }, // Suction Power(AW)
                new ProductAttribute { ProductID = 8, AttributeID = 17, AttributeValue = "5.5" }, // Weight
                new ProductAttribute { ProductID = 8, AttributeID = 22, AttributeValue = "Cordless" },
                new ProductAttribute { ProductID = 8, AttributeID = 23, AttributeValue = "24" }, // Battery Voltage

                // 2-Slice Toaster
                new ProductAttribute { ProductID = 9, AttributeID = 24, AttributeValue = "2" }, // Slice Capacity
                new ProductAttribute { ProductID = 9, AttributeID = 25, AttributeValue = "6" }, // Toasting Levels
                new ProductAttribute { ProductID = 9, AttributeID = 26, AttributeValue = "850" }, // Power
                new ProductAttribute { ProductID = 9, AttributeID = 27, AttributeValue = "Yes" }, // Bagel Setting
                new ProductAttribute { ProductID = 9, AttributeID = 28, AttributeValue = "Yes" }, // Defrost Function
                new ProductAttribute { ProductID = 9, AttributeID = 29, AttributeValue = "Yes" }, // Crumb Tray

                // 4-Slice Toaster
                new ProductAttribute { ProductID = 10, AttributeID = 24, AttributeValue = "4" }, // Slice Capacity
                new ProductAttribute { ProductID = 10, AttributeID = 25, AttributeValue = "7" }, // Toasting Levels
                new ProductAttribute { ProductID = 10, AttributeID = 26, AttributeValue = "1800" }, // Power
                new ProductAttribute { ProductID = 10, AttributeID = 27, AttributeValue = "Yes" }, // Bagel Setting
                new ProductAttribute { ProductID = 10, AttributeID = 28, AttributeValue = "Yes" }, // Defrost Function
                new ProductAttribute { ProductID = 10, AttributeID = 29, AttributeValue = "Yes" }, // Crumb Tray

                // Single-Door Refrigerator
                new ProductAttribute { ProductID = 11, AttributeID = 30, AttributeValue = "Single" },
                new ProductAttribute { ProductID = 11, AttributeID = 31, AttributeValue = "10" }, // Total Capacity(cu. ft.)
                new ProductAttribute { ProductID = 11, AttributeID = 32, AttributeValue = "3" }, // Freezer Capacity(cu. ft.)
                new ProductAttribute { ProductID = 11, AttributeID = 17, AttributeValue = "130" }, // Weight(lbs)
                new ProductAttribute { ProductID = 11, AttributeID = 34, AttributeValue = "Yes" }, // Energy Star Certified
                new ProductAttribute { ProductID = 11, AttributeID = 35, AttributeValue = "No" }, // Ice Maker

                // Double-Door Refrigerator
                new ProductAttribute { ProductID = 12, AttributeID = 30, AttributeValue = "Double" },
                new ProductAttribute { ProductID = 12, AttributeID = 31, AttributeValue = "22" }, // Total Capacity(cu. ft.)
                new ProductAttribute { ProductID = 12, AttributeID = 32, AttributeValue = "7" }, // Freezer Capacity(cu. ft.)
                new ProductAttribute { ProductID = 12, AttributeID = 17, AttributeValue = "220" }, // Weight(lbs)
                new ProductAttribute { ProductID = 12, AttributeID = 34, AttributeValue = "Yes" }, // Energy Star Certified
                new ProductAttribute { ProductID = 12, AttributeID = 35, AttributeValue = "Yes" }, // Ice Maker

                // Microwave Oven
                new ProductAttribute { ProductID = 13, AttributeID = 36, AttributeValue = "Electric" },
                new ProductAttribute { ProductID = 13, AttributeID = 37, AttributeValue = "1.2" }, // Oven Capacity(cu. ft.)
                new ProductAttribute { ProductID = 13, AttributeID = 26, AttributeValue = "1200" }, // Power(W)
                new ProductAttribute { ProductID = 13, AttributeID = 39, AttributeValue = "Yes" }, // Self Cleaning
                new ProductAttribute { ProductID = 13, AttributeID = 40, AttributeValue = "No" }, // Convection
                new ProductAttribute { ProductID = 13, AttributeID = 41, AttributeValue = "1" }, // Number of Oven Racks

                // Convection Oven
                new ProductAttribute { ProductID = 14, AttributeID = 36, AttributeValue = "Electric" },
                new ProductAttribute { ProductID = 14, AttributeID = 37, AttributeValue = "2.5" }, // Oven Capacity(cu. ft.)
                new ProductAttribute { ProductID = 14, AttributeID = 26, AttributeValue = "1800" }, // Power(W)
                new ProductAttribute { ProductID = 14, AttributeID = 39, AttributeValue = "Yes" }, // Self Cleaning
                new ProductAttribute { ProductID = 14, AttributeID = 40, AttributeValue = "Yes" }, // Convection
                new ProductAttribute { ProductID = 14, AttributeID = 41, AttributeValue = "2" }, // Number of Oven Racks

                // Lined Notebook
                new ProductAttribute { ProductID = 15, AttributeID = 42, AttributeValue = "Lined" },
                new ProductAttribute { ProductID = 15, AttributeID = 43, AttributeValue = "200" }, // Page Count
                new ProductAttribute { ProductID = 15, AttributeID = 44, AttributeValue = "80" }, // Paper Weight(gsm)
                new ProductAttribute { ProductID = 15, AttributeID = 45, AttributeValue = "Hardcover" }, // Cover Material
                new ProductAttribute { ProductID = 15, AttributeID = 46, AttributeValue = "Spiral" }, // Binding
                new ProductAttribute { ProductID = 15, AttributeID = 47, AttributeValue = "8" }, // Line Spacing(mm)

                // Graph Notebook
                new ProductAttribute { ProductID = 16, AttributeID = 42, AttributeValue = "Graph" },
                new ProductAttribute { ProductID = 16, AttributeID = 43, AttributeValue = "150" }, // Page Count
                new ProductAttribute { ProductID = 16, AttributeID = 44, AttributeValue = "90" }, // Paper Weight(gsm)
                new ProductAttribute { ProductID = 16, AttributeID = 45, AttributeValue = "Softcover" }, // Cover Material
                new ProductAttribute { ProductID = 16, AttributeID = 46, AttributeValue = "Saddle Stitched" }, // Binding
                new ProductAttribute { ProductID = 16, AttributeID = 47, AttributeValue = "10" }, // Line Spacing(mm)

                // Ballpoint Pen
                new ProductAttribute { ProductID = 17, AttributeID = 48, AttributeValue = "Black" },
                new ProductAttribute { ProductID = 17, AttributeID = 49, AttributeValue = "Oil-based" }, // Ink Type
                new ProductAttribute { ProductID = 17, AttributeID = 50, AttributeValue = "0.7" }, // Line Width(mm)
                new ProductAttribute { ProductID = 17, AttributeID = 51, AttributeValue = "Yes" }, // Retractable
                new ProductAttribute { ProductID = 17, AttributeID = 52, AttributeValue = "Rubber" }, // Grip Type
                new ProductAttribute { ProductID = 17, AttributeID = 53, AttributeValue = "Plastic" }, // Material

                // Fountain Pen
                new ProductAttribute { ProductID = 18, AttributeID = 48, AttributeValue = "Blue" },
                new ProductAttribute { ProductID = 18, AttributeID = 49, AttributeValue = "Water-based" }, // Ink Type
                new ProductAttribute { ProductID = 18, AttributeID = 50, AttributeValue = "0.5" }, // Line Width(mm)
                new ProductAttribute { ProductID = 18, AttributeID = 51, AttributeValue = "No" }, // Retractable
                new ProductAttribute { ProductID = 18, AttributeID = 52, AttributeValue = "Knurled" }, // Grip Type
                new ProductAttribute { ProductID = 18, AttributeID = 53, AttributeValue = "Metal" }, // Material

                // Office Chair
                new ProductAttribute { ProductID = 19, AttributeID = 53, AttributeValue = "Leather" },
                new ProductAttribute { ProductID = 19, AttributeID = 55, AttributeValue = "300" }, // Max Weight Capacity(lbs)
                new ProductAttribute { ProductID = 19, AttributeID = 17, AttributeValue = "35" }, // Weight(lbs)
                new ProductAttribute { ProductID = 19, AttributeID = 57, AttributeValue = "Office" }, // Chair Type
                new ProductAttribute { ProductID = 19, AttributeID = 58, AttributeValue = "Yes" }, // Adjustable Height
                new ProductAttribute { ProductID = 19, AttributeID = 59, AttributeValue = "Yes" }, // Armrest

                // Dining Chair
                new ProductAttribute { ProductID = 20, AttributeID = 53, AttributeValue = "Wood" },
                new ProductAttribute { ProductID = 20, AttributeID = 55, AttributeValue = "250" },
                new ProductAttribute { ProductID = 20, AttributeID = 17, AttributeValue = "15" },
                new ProductAttribute { ProductID = 20, AttributeID = 57, AttributeValue = "Dining" },
                new ProductAttribute { ProductID = 20, AttributeID = 58, AttributeValue = "No" },
                new ProductAttribute { ProductID = 20, AttributeID = 59, AttributeValue = "No" },

                // Recliner Chair
                new ProductAttribute { ProductID = 21, AttributeID = 53, AttributeValue = "Leather" },
                new ProductAttribute { ProductID = 21, AttributeID = 55, AttributeValue = "350" },
                new ProductAttribute { ProductID = 21, AttributeID = 17, AttributeValue = "40" },
                new ProductAttribute { ProductID = 21, AttributeID = 57, AttributeValue = "Recliner" },
                new ProductAttribute { ProductID = 21, AttributeID = 58, AttributeValue = "Yes" },
                new ProductAttribute { ProductID = 21, AttributeID = 59, AttributeValue = "Yes" },

                // Writing Desk
                new ProductAttribute { ProductID = 22, AttributeID = 53, AttributeValue = "Wood" },
                new ProductAttribute { ProductID = 22, AttributeID = 61, AttributeValue = "Writing" }, // Desk Type
                new ProductAttribute { ProductID = 22, AttributeID = 62, AttributeValue = "48" }, // Width(in)
                new ProductAttribute { ProductID = 22, AttributeID = 63, AttributeValue = "24" }, // Depth(in)
                new ProductAttribute { ProductID = 22, AttributeID = 64, AttributeValue = "30" }, // Height(in)
                new ProductAttribute { ProductID = 22, AttributeID = 65, AttributeValue = "1" }, // Number of Drawers
                new ProductAttribute { ProductID = 22, AttributeID = 66, AttributeValue = "No" }, // Adjustable Height

                // Computer Desk
                new ProductAttribute { ProductID = 23, AttributeID = 53, AttributeValue = "Metal" },
                new ProductAttribute { ProductID = 23, AttributeID = 61, AttributeValue = "Computer" },
                new ProductAttribute { ProductID = 23, AttributeID = 62, AttributeValue = "60" },
                new ProductAttribute { ProductID = 23, AttributeID = 63, AttributeValue = "30" },
                new ProductAttribute { ProductID = 23, AttributeID = 64, AttributeValue = "29" },
                new ProductAttribute { ProductID = 23, AttributeID = 65, AttributeValue = "2" },
                new ProductAttribute { ProductID = 23, AttributeID = 66, AttributeValue = "Yes" },

            };
            foreach (var productAttribute in productAttributes)
            {
                context.AttributeValues.AddOrUpdate(productAttribute);
            }


            var techSpecfilters = new List<TechSpecFilter>
            {
                // TechSpecFilter for Fans
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 5, MinValue = 1000, MaxValue = 7000 }, // Air Flow(CFM)
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 6, MinValue = 10, MaxValue = 500 }, // Power(W)_Min
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 7, MinValue = 100, MaxValue = 1000 }, // Power(W)_Max
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 8, MinValue = 110, MaxValue = 240 }, // Operating Voltage(VAC)_Min
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 9, MinValue = 110, MaxValue = 240 }, // Operating Voltage(VAC)_Max
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 10, MinValue = 100, MaxValue = 3000 }, // Fan Speed(RPM)_Min
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 11, MinValue = 1500, MaxValue = 5000 }, // Fan Speed(RPM)_Max
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 12, MinValue = 1, MaxValue = 5 }, // Number of Fan Speeds
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 13, MinValue = 10, MaxValue = 60 }, // Sound at Max Speed(dBA)
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 14, MinValue = 10, MaxValue = 60 }, // Fan Sweep Diameter(in)
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 15, MinValue = 10, MaxValue = 60 }, // Height(in)_Min
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 16, MinValue = 10, MaxValue = 60 }, // Height(in)_Max
                new TechSpecFilter { SubCategoryID = 1, AttributeID = 17, MinValue = 5, MaxValue = 30 }, // Weight(lbs)

                // TechSpecFilter for Vacuums
                new TechSpecFilter { SubCategoryID = 2, AttributeID = 19, MinValue = 0, MaxValue = 5 }, // Bin Capacity
                new TechSpecFilter { SubCategoryID = 2, AttributeID = 20, MinValue = 100, MaxValue = 500 }, // Suction Power
                new TechSpecFilter { SubCategoryID = 2, AttributeID = 17, MinValue = 5, MaxValue = 30 }, // Weight(lbs)
                new TechSpecFilter { SubCategoryID = 2, AttributeID = 23, MinValue = 12, MaxValue = 24 }, // Battery Voltage(V)

                // TechSpecFilter for Toasters
                new TechSpecFilter { SubCategoryID = 3, AttributeID = 25, MinValue = 3, MaxValue = 10 }, // Toasting Levels
                new TechSpecFilter { SubCategoryID = 3, AttributeID = 26, MinValue = 500, MaxValue = 1500 }, // Power(W)

                // TechSpecFilter for Refrigerators
                new TechSpecFilter { SubCategoryID = 4, AttributeID = 31, MinValue = 10, MaxValue = 30 }, // Total Capacity(cu. ft.)
                new TechSpecFilter { SubCategoryID = 4, AttributeID = 32, MinValue = 0, MaxValue = 10 }, // Freezer Capacity(cu. ft.)
                new TechSpecFilter { SubCategoryID = 4, AttributeID = 17, MinValue = 100, MaxValue = 500 }, // Weight(lbs)

                // TechSpecFilter for Ovens
                new TechSpecFilter { SubCategoryID = 5, AttributeID = 37, MinValue = 1, MaxValue = 10 }, // Oven Capacity(cu. ft.)
                new TechSpecFilter { SubCategoryID = 5, AttributeID = 26, MinValue = 1000, MaxValue = 5000 }, // Power(W)
                new TechSpecFilter { SubCategoryID = 5, AttributeID = 41, MinValue = 1, MaxValue = 5 }, // Number of Oven Racks

                // TechSpecFilter for Notebooks
                new TechSpecFilter { SubCategoryID = 6, AttributeID = 43, MinValue = 50, MaxValue = 200 }, // Page Count
                new TechSpecFilter { SubCategoryID = 6, AttributeID = 44, MinValue = 60, MaxValue = 120 }, // Paper Weight(gsm)
                new TechSpecFilter { SubCategoryID = 6, AttributeID = 47, MinValue = 5, MaxValue = 10 }, // Line Spacing(mm)

                // TechSpecFilter for Pens
                new TechSpecFilter { SubCategoryID = 7, AttributeID = 50, MinValue = 0, MaxValue = 1 }, // Line Width(mm)


                // TechSpecFilter for Chairs
                new TechSpecFilter { SubCategoryID = 8, AttributeID = 55, MinValue = 200, MaxValue = 400 }, // Max Weight Capacity(lbs)
                new TechSpecFilter { SubCategoryID = 8, AttributeID = 17, MinValue = 10, MaxValue = 50 }, // Weight(lbs)

                // TechSpecFilter for Desks
                new TechSpecFilter { SubCategoryID = 9, AttributeID = 62, MinValue = 40, MaxValue = 80 }, // Width(in)
                new TechSpecFilter { SubCategoryID = 9, AttributeID = 63, MinValue = 20, MaxValue = 40 }, // Depth(in)
                new TechSpecFilter { SubCategoryID = 9, AttributeID = 64, MinValue = 20, MaxValue = 40 }, // Height(in)
                new TechSpecFilter { SubCategoryID = 9, AttributeID = 65, MinValue = 0, MaxValue = 5 }, // Number of Drawers

            };
            foreach (var techSpecFilter in techSpecfilters)
            {
                context.TechSpecFilters.AddOrUpdate(techSpecFilter);
            }
            context.SaveChanges();
        }
    }
}
