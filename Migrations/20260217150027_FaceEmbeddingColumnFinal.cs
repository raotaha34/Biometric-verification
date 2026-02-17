using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Face_Recognition.Migrations
{
    /// <inheritdoc />
    public partial class FaceEmbeddingColumnFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FaceEmbedding",
                table: "FaceImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceEmbedding",
                table: "FaceImages");
        }
    }
}
