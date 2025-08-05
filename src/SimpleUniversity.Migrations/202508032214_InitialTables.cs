using FluentMigrator;

namespace SimpleUniversity.Migrations
{
    [Migration(202508032214)]
    public class _202508032214_InitialTables : Migration
    {
        public override void Up()
        {
            Create.Table("Terms")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("StartDate").AsDateTime2().NotNullable()
                .WithColumn("EndDate").AsDateTime2().NotNullable();

            Create.Table("Courses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("Unit").AsInt16().NotNullable();

            Create.Table("Classes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CourseId").AsInt32().NotNullable()
                .WithColumn("TermId").AsInt32().NotNullable()
                .WithColumn("TeacherId").AsInt32().NotNullable()
                .WithColumn("Capacity").AsInt32().NotNullable();

            Create.Table("Persons")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("NationalCode").AsString(10).NotNullable()
                .WithColumn("BirthDate").AsDateTime2().NotNullable()
                .WithColumn("Code").AsString(10).NotNullable()
                .WithColumn("FatherName").AsString(50).NotNullable()
                .WithColumn("Gender").AsByte().NotNullable()
                .WithColumn("Phone").AsString(15).Nullable()
                .WithColumn("Address").AsString(200).Nullable()
                .WithColumn("PersonType").AsByte().NotNullable();

            Create.Table("Sections")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ClassId").AsInt32().NotNullable()
                .WithColumn("DayOfWeek").AsInt32().NotNullable()
                .WithColumn("StartTime").AsTime().NotNullable()
                .WithColumn("EndTime").AsTime().NotNullable();

            Create.Table("SelectedClasses")
                .WithColumn("StudentId").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("ClassId").AsInt32().NotNullable().PrimaryKey();


            Create.ForeignKey("FK_Classes_Courses")
                .FromTable("Classes").ForeignColumn("CourseId")
                .ToTable("Courses").PrimaryColumn("Id");

            Create.ForeignKey("FK_Classes_Terms")
                .FromTable("Classes").ForeignColumn("TermId")
                .ToTable("Terms").PrimaryColumn("Id");

            Create.ForeignKey("Fk_Classes_Teachers")
                .FromTable("Classes").ForeignColumn("TeacherId")
                .ToTable("Persons").PrimaryColumn("Id");

            Create.ForeignKey("FK_Sections_Classes")
                .FromTable("Sections").ForeignColumn("ClassId")
                .ToTable("Classes").PrimaryColumn("Id");

            Create.ForeignKey("FK_SelectedClasses_Students")
                .FromTable("SelectedClasses").ForeignColumn("StudentId")
                .ToTable("Persons").PrimaryColumn("Id");

            Create.ForeignKey("FK_SelectedClasses_Classes")
                .FromTable("SelectedClasses").ForeignColumn("ClassId")
                .ToTable("Classes").PrimaryColumn("Id");
        }
        
        public override void Down()
        {
            Delete.ForeignKey("FK_SelectedClasses_Classes").OnTable("SelectedClasses");
            Delete.ForeignKey("FK_SelectedClasses_Students").OnTable("SelectedClasses");
            Delete.ForeignKey("FK_Sections_Classes").OnTable("Sections");
            Delete.ForeignKey("Fk_Classes_Teachers").OnTable("Classes");
            Delete.ForeignKey("FK_Classes_Terms").OnTable("Classes");
            Delete.ForeignKey("FK_Classes_Courses").OnTable("Classes");

            Delete.Table("SelectedClasses");
            Delete.Table("Sections");
            Delete.Table("Persons");
            Delete.Table("Classes");
            Delete.Table("Courses");
            Delete.Table("Terms");
        }
    }
}
