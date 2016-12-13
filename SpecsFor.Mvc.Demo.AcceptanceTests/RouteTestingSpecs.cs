﻿using NUnit.Framework;
using SpecsFor.Mvc.Demo.Areas.Tasks.Controllers;
using SpecsFor.Mvc.Helpers;

namespace SpecsFor.Mvc.Demo.AcceptanceTests
{
    public class RouteTestingSpecs
    {
        public class when_verifying_a_route_that_contains_query_string_parameters : SpecsFor<MvcWebApp>
        {
            protected override void When()
            {
                Assert.AreEqual(1, 2);
                SUT.NavigateTo<ListController>(c => c.Edit(5, "test"));
            }

            [Test]
            public void then_it_correctly_matches_the_same_route()
            {
                SUT.Route.ShouldMapTo<ListController>(c => c.Edit(5, "test"));
            }

            [Test]
            public void then_it_throws_an_exception_on_a_different_route()
            {
                Assert.Throws<RouteAssertionException>(() => SUT.Route.ShouldMapTo<ListController>(c => c.Edit(4, "other")));
            }
        }
    }
}