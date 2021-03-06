﻿namespace Microsoft.AspNetCore.Mvc.Versioning.Conventions
{
    using ApplicationModels;
    using System;
    using System.Reflection;

    /// <content>
    /// Provides additional implementation specific to Microsoft ASP.NET Core.
    /// </content>
    [CLSCompliant( false )]
    public partial class ControllerApiVersionConventionBuilder : IActionConventionBuilder
    {
        /// <summary>
        /// Attempts to get the convention for the specified action method.
        /// </summary>
        /// <param name="method">The <see cref="MethodInfo">method</see> representing the action to retrieve the convention for.</param>
        /// <param name="convention">The retrieved <see cref="IApiVersionConvention{T}">convention</see> or <c>null</c>.</param>
        /// <returns></returns>
        protected override bool TryGetConvention( MethodInfo method, out IApiVersionConvention<ActionModel> convention )
        {
            Arg.NotNull( method, nameof( method ) );

            if ( ActionBuilders.TryGetValue( method, out var actionBuilder ) )
            {
                convention = actionBuilder;
                return true;
            }

            convention = default( IApiVersionConvention<ActionModel> );
            return false;
        }
    }
}