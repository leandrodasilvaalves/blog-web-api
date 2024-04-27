using System.ComponentModel.DataAnnotations;

using AutoFixture.Xunit2;

using Bogus;

namespace Blog.UnitTests.Fixtures.Attributes;

public class AutoInlineDataAttribute : CompositeDataAttribute
{
    private readonly static Faker Faker = new();

    public AutoInlineDataAttribute(params object[] values)
        : base(new InlineDataAttribute(values),
               new AuthorsAutoDataAttribute(),
               new AutoDataAttribute())
    { }

    /// <summary>
    /// Generate fake data for testing
    /// </summary>
    /// <param name="dataType">DataType must always be something like string</param>
    /// <param name="length">Minimum size of fake data to be generated</param>
    public AutoInlineDataAttribute(DataType dataType, int length = 0)
        : this(GenerateFakeString(dataType, length)) { }

    private static string GenerateFakeString(DataType dataType, int length) => dataType switch
    {
        DataType.EmailAddress => $"{Faker.Random.String(length)}.{Faker.Person.Email}",
        DataType.Text => Faker.Random.String(length),
        _ => throw new InvalidOperationException("Data Type can't be generated as string")
    };
}