using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data.Configuration
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
           builder.HasData(ConfigurationHelper.OpenBoard,
                         ConfigurationHelper.InProgressBoard,
                         ConfigurationHelper.DoneBoard);
        }
    }
}
