using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Game.Context;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerModel>().HasKey(_ => _.Uid);
    }
}