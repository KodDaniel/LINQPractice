using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqStudiekollen.LinqQueries;

namespace LinqStudiekollen
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ Queries below
            var context = new StudieContext();


            //LinqSyntax.LinqRestriction(context);

            //LinqSyntax.LinqOrdering(context);

            //LinqSyntax.LinqProjection(context);

            //LinqSyntax.LinqGrouping(context);

            //LinqSyntax.LinqJoining(context);

            //.....................................................................................................

            //LinqExtensionMethod.LinqExtensionRestriction(context);

            //LinqExtensionMethod.LinqExtensionOrdering(context);

            //LinqExtensionMethod.LinqExtensionProjection(context);

            //LinqExtensionMethod.LinqExtensionDistinct(context);

            //LinqExtensionMethod.LinqExtensionGrouping(context);

            //LinqExtensionMethod.LinqExtensionJoining(context);

            //LinqExtensionMethod.LinqExtensionFirstAndLastOperator(context);

            //LinqExtensionMethod.LinqExtensionSingleAndAllOperator(context);

            //LinqExtensionMethod.LinqExtensionAggregating(context);

            //LinqExtensionMethod.LinqExtensionMethodPartitioning(context);

            //.....................................................................................................
            //DeferredExecution.DeferredMethod(context);
            //.....................................................................................................

            //Loading.LazyLoadingMethod(context);

            Loading.NPlus1Problem(context);










        }




    }






}
