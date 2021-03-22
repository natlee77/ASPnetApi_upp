#pragma checksum "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f043b2e72d4d6e65890583fbd3ae377ffdcce59"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Blazor.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\46735\Desktop\CaseManager\Blazor\_Imports.razor"
using LibraryProject.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/customers")]
    public partial class Customers : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Blazor.Shared.Auth>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\r\n\r\n \r\n\r\n\r\n\r\n");
            __builder.AddMarkupContent(2, "<h3>Customers</h3>");
#nullable restore
#line 10 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
 if (customers == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(3, "<p><em>Not found...</em></p>");
#nullable restore
#line 13 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "table");
            __builder.AddAttribute(5, "class", "table");
            __builder.AddMarkupContent(6, "<thead><tr><th>#</th> \r\n                <th>First Name</th>\r\n                <th>Last Name</th>\r\n                <th>Email</th></tr></thead>\r\n        ");
            __builder.OpenElement(7, "tbody");
#nullable restore
#line 27 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
             foreach (var customer in customers)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "tr");
            __builder.OpenElement(9, "td");
            __builder.AddContent(10, 
#nullable restore
#line 30 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
                         customer.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n                    ");
            __builder.OpenElement(12, "td");
            __builder.AddContent(13, 
#nullable restore
#line 31 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
                         customer.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                    ");
            __builder.OpenElement(15, "td");
            __builder.AddContent(16, 
#nullable restore
#line 32 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
                         customer.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                    ");
            __builder.OpenElement(18, "td");
            __builder.AddContent(19, 
#nullable restore
#line 33 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
                         customer.Email

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 35 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 38 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "C:\Users\46735\Desktop\CaseManager\Blazor\Pages\Customers.razor"
       
    //bestämma hur issues ska ser ut
    private IEnumerable<CustomerViewModel> customers;

    protected override async Task OnInitializedAsync()
    {
        customers = await http.GetFromJsonAsync<IEnumerable<CustomerViewModel>>("https://localhost:44301/api/customers?Key=20l5g437kUGFYzUkjDumZw%==");
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }
    }
}
#pragma warning restore 1591
