// See https://aka.ms/new-console-template for more information
using StronglyTypedId;

using TestEntities context = new TestEntities();
context.TestTable.Add(new TestTable());
context.SaveChanges();

Console.ReadLine();