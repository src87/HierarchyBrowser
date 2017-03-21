using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Faker;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.Data
{
    internal class FakeDataProvider : IDataProvider
    {
        private const int RootCount = 100;
        private readonly List<Person> _people = new List<Person>();

        public FakeDataProvider()
        {
            CreateFakeData();
        }

        public IEnumerable<IHierarchyItem> Get(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return _people;

            Thread.Sleep(1000);

            var terms = text.Split(' ');
            var results = _people.Where(p => Found(terms, p.Name));
            return results;
        }

        private static bool Found(IEnumerable<string> terms, string name)
        {
            var names = name.Split(' ');
            var found = true;
            foreach (var term in terms)
            {
                if (!names.Any(n => n.StartsWith(term, true, CultureInfo.InvariantCulture)))
                    found = false;
            }
            return found;
        }

        private void CreateFakeData()
        {
            for (int i = 0; i < RootCount; i++)
            {
                var p = new Person
                {
                    Name = Name.FullName()
                };

                for (int j = 0; j < 3; j++)
                {
                    var p2 = new Person
                    {
                        Name = Name.FullName()
                    };

                    p2.Parents.Add(p);
                    p.Children.Add(p2);
                    _people.Add(p2);

                    for (int k = 0; k < 3; k++)
                    {
                        var p3 = new Person
                        {
                            Name = Name.FullName()
                        };

                        var p4 = new Person
                        {
                            Name = Name.FullName()
                        };

                        p3.Parents.Add(p2);
                        p2.Children.Add(p3);
                        p4.Children.Add(p3);
                        p3.Parents.Add(p4);
                        _people.Add(p3);
                        _people.Add(p4);
                    }
                }
                _people.Add(p);
            }
        }
    }
}