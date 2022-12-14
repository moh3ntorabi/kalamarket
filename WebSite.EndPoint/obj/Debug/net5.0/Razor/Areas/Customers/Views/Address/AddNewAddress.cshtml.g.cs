#pragma checksum "C:\Users\Phoenix\source\Advance\Project\StarStore\WebSite.EndPoint\Areas\Customers\Views\Address\AddNewAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e5408b2337bdc9b43247e11a45920a526270c20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customers_Views_Address_AddNewAddress), @"mvc.1.0.view", @"/Areas/Customers/Views/Address/AddNewAddress.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e5408b2337bdc9b43247e11a45920a526270c20", @"/Areas/Customers/Views/Address/AddNewAddress.cshtml")]
    public class Areas_Customers_Views_Address_AddNewAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.Services.Users.AddUserAddressDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Phoenix\source\Advance\Project\StarStore\WebSite.EndPoint\Areas\Customers\Views\Address\AddNewAddress.cshtml"
  
    ViewData["Title"] = "AddNewAddress";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""checkout-section shadow-around"">
    <div class=""checkout-section-content"">
        <form method=""post"" asp-action=""AddNewAddress"" asp-controller=""Address"" asp-area=""customers"" data-select2-id=""select2-data-18-nzre"">
            <div class=""row"" data-select2-id=""select2-data-17-414m"">
                <div class=""col-lg-6 mb-3"">
                    <div class=""text-sm text-muted mb-1"">استان:</div>
                    <div class=""text-dark font-weight-bold"">
                        <div class=""form-element-row mb-0"">
                            <input type=""text"" class=""input-element"" asp-for=""State"">
                        </div>
                    </div>
                </div>

                <div class=""col-lg-6 mb-3"">
                    <div class=""text-sm text-muted mb-1"">شهر:</div>
                    <div class=""text-dark font-weight-bold"">
                        <div class=""form-element-row mb-0"">
                            <input type=""text"" class=""input-element"" as");
            WriteLiteral(@"p-for=""City"">
                        </div>
                    </div>
                </div>


                <div class=""col-lg-6 mb-3"">
                    <div class=""text-sm text-muted mb-1"">کد پستی:</div>
                    <div class=""text-dark font-weight-bold"">
                        <div class=""form-element-row mb-0"">
                            <input type=""text"" class=""input-element"" asp-for=""ZipCode"">
                        </div>
                    </div>
                </div>

                <div class=""col-lg-6 mb-3"">
                    <div class=""text-sm text-muted mb-1""> نام گیرنده:</div>
                    <div class=""text-dark font-weight-bold"">
                        <div class=""form-element-row mb-0"">
                            <input type=""text"" class=""input-element"" asp-for=""ReciverName"">
                        </div>
                    </div>
                </div>
                <div class=""col-12 mb-3"">
                    <div class=""text-sm ");
            WriteLiteral(@"text-muted mb-1"">آدرس کامل:</div>
                    <div class=""text-dark font-weight-bold"">
                        <div class=""form-element-row mb-0"">
                            <textarea asp-for=""PostalAddress"" cols=""30"" rows=""10"" class=""input-element""></textarea>
                        </div>
                    </div>
                </div>
                <div class=""col-12 mb-3"">
                    <button type=""submit"" class=""btn btn-primary"">ذخیره تغییرات <i class=""fad fa-money-check-edit""></i></button>
                </div>
            </div>
        </form>

    </div>
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.Services.Users.AddUserAddressDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
