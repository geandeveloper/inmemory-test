// See https://aka.ms/new-console-template for more information
using InMemoryTest;
using InMemoryTest.ClaimRecoveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var contextOptions = new DbContextOptionsBuilder<InMemoryContext>()
   .UseInMemoryDatabase(nameof(InMemoryContext))
   .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
   .Options;

using var context = new InMemoryContext(contextOptions);

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

context.AddRange(
    new ClaimRecovery(1, 1, 1),
    new ClaimRecovery(2, 2, 2),
    new ClaimRecovery(3, 3, 3)
    );

context.SaveChanges();

var repository = new InMemoryRepository<ClaimRecovery>(context);

var claim = await repository.FirstAsync(ac => ac.ClientId == 2 && ac.ClaimId == 2);

Console.WriteLine($"found {claim?.Id}");
