#pragma checksum "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55f91dc81678a87c166f5c6c1bf7cd15e6f1324d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Discount_Index), @"mvc.1.0.view", @"/Views/Discount/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\_ViewImports.cshtml"
using AdminSite.Endpoint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\_ViewImports.cshtml"
using AdminSite.Endpoint.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
using Application.Services.Discounts.CRUDServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
using Application.Dtos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55f91dc81678a87c166f5c6c1bf7cd15e6f1324d", @"/Views/Discount/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbd196d5ee4da5b4be5283ad54931b9f2d1e8c35", @"/Views/_ViewImports.cshtml")]
    public class Views_Discount_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedItemsDto<DiscountDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddDiscount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dt-button buttons-print btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55f91dc81678a87c166f5c6c1bf7cd15e6f1324d5864", async() => {
                WriteLiteral("ثبت تخفیف جدید");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>

<div class=""table-responsive"">
    <table class=""table table-bordered table-hover table-striped table-checkable table-highlight-head mb-4"">
        <thead>
            <tr>
                
                <th>
                    نام تخفیف
                </th>
                <th>
                    تخفیف برای محصول
                </th>
                <th>
                    درصد تخفیف
                </th>
                <th>
                    مبلغ تخفیف
                </th>
                <th>
                    زمان شروع
                </th>
                <th>
                    زمان انقضا
                </th>
                <th>
                </th>
                
                
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 46 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
             foreach (var item in Model.Data)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    \r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 56 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                         foreach (var catalog in item.CatalogItems)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => catalog.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                                                                       
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DiscountPercentage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DiscountAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    \r\n                    <td class=\"text-center\">\r\n                        \r\n                            \r\n                        <button  class=\"btn btn-outline-primary mx-5\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2288, "\"", 2417, 9);
            WriteAttributeValue("", 2298, "ShowModalDiscountDetail(\'", 2298, 25, true);
#nullable restore
#line 77 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
WriteAttributeValue("", 2323, item.CouponCode, 2323, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2339, "\',\'", 2339, 3, true);
#nullable restore
#line 77 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
WriteAttributeValue("", 2342, item.DiscountTypeId, 2342, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2362, "\',\'", 2362, 3, true);
#nullable restore
#line 77 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
WriteAttributeValue("", 2365, item.DiscountLimitationId, 2365, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2391, "\',\'", 2391, 3, true);
#nullable restore
#line 77 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
WriteAttributeValue("", 2394, item.LimitationTimes, 2394, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2415, "\')", 2415, 2, true);
            EndWriteAttribute();
            WriteLiteral(">مشاهده جزئیات</button>\r\n                        <a data-toggle=\"tooltip\" data-placement=\"top\" title=\"حذف\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2524, "\"", 2572, 6);
            WriteAttributeValue("", 2534, "DeleteDiscount(\'", 2534, 16, true);
#nullable restore
#line 78 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
WriteAttributeValue("", 2550, item.Id, 2550, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2558, "\',", 2558, 2, true);
            WriteAttributeValue(" ", 2560, "\'", 2561, 2, true);
#nullable restore
#line 78 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
WriteAttributeValue("", 2562, item.Id, 2562, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2570, "\')", 2570, 2, true);
            EndWriteAttribute();
            WriteLiteral(@"><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-trash-2 text-danger""><polyline points=""3 6 5 6 21 6""></polyline><path d=""M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2""></path><line x1=""10"" y1=""11"" x2=""10"" y2=""17""></line><line x1=""14"" y1=""11"" x2=""14"" y2=""17""></line></svg></a>
                    </td>
                </tr>
");
#nullable restore
#line 81 "C:\Users\Phoenix\source\Advance\Project\StarStore\AdminSite.Endpoint\Views\Discount\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "55f91dc81678a87c166f5c6c1bf7cd15e6f1324d14572", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55f91dc81678a87c166f5c6c1bf7cd15e6f1324d15687", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>

    function DeleteDiscount(discountid, discounname) {
        swal.fire({
            title: 'حذف تخفیف',
            text: ""کاربر گرامی از حذف "" + discounname + "" مطمئن هستید؟"",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#7cacbe',
            confirmButtonText: 'بله، حذف شود',
            cancelButtonText: 'خیر'
        }).then((result) => {
            if (result.value) {
                var postData = {
                    'Id': discountid,
                };

                $.ajax({
                    contentType: 'application/x-www-form-urlencoded',
                    dataType: 'json',
                    type: ""POST"",
                    url: ""Delete"",
                    data: postData,
                    success: function (data) {
                        if (data.isSuccess == true) {
                            swal.fire(
                                'موفق!',
  ");
            WriteLiteral(@"                              data.message,
                                'success'
                            ).then(function (isConfirm) {
                                location.reload();
                            });
                        }
                        else {
                            swal.fire(
                                'هشدار!',
                                data.message,
                                'warning'
                            );
                        }
                    },
                    error: function (request, status, error) {
                        alert(request.responseText);
                    }
                });
            }
        })
    }

    function ShowModalDiscountDetail(CouponCode, DiscountTypeId, DiscountLimitationId, LimitationTimes) {
        $('#CouponCode').html(CouponCode);
        $('#LimitationTimes').html(LimitationTimes);
        
        switch (DiscountLimitationId) {
            case '0':
");
            WriteLiteral(@"                $('#DiscountLimitation').html(""بدونه محدودیت تعداد"");
                break;
            case '1':
                $('#DiscountLimitation').html(""فقط N بار"");
                break;
            case '2':
                $('#DiscountLimitation').html(""N بار به ازای هر مشتری"");
                break;
            default: $('#DiscountLimitation').html(""تعداد تخفیف"");
        }
        
        switch (DiscountTypeId) {
            case '0':
                $('#DiscountType').html(""تخفیف برای محصول"");
                break;
            case '1':
                $('#DiscountType').html(""تخفیف برای دسته بندی"");
                break;
            case '2':
                $('#DiscountType').html(""تخفیف برای مشتری"");
                break;
            case '3':
                $('#DiscountType').html(""تخفیف برای برند"");
                break;
            default: $('#DiscountType').html(""نوع تخفیف"");
        }
        $('#DiscountDetail').modal('show');

    }

</script>");
            WriteLiteral("\n\r\n\r\n\r\n");
            DefineSection("Modals", async() => {
                WriteLiteral(@"
    <!-- Modal Edit User -->
    <div class=""modal fade"" id=""DiscountDetail"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLongTitle"">جزئیات تخفیف</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>

                <div class=""modal-body"">
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                        <fieldset class=""form-group"">
                            <label for=""basicInput"">کد تخفیف</label>
                            <span type=""text"" class=""form-control"" id=""CouponCode""></span>
                        </fieldset>
                  ");
                WriteLiteral(@"  </div>
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                        <fieldset class=""form-group"">
                            <label for=""basicInput"">نوع تخفیف</label>
                            <span type=""text"" class=""form-control"" id=""DiscountType""></span>
                        </fieldset>
                    </div>
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                        <fieldset class=""form-group"">
                            <label for=""basicInput"">محدودیت تخفیف</label>
                            <span type=""text"" class=""form-control"" id=""DiscountLimitation""></span>
                        </fieldset>
                    </div>
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                        <fieldset class=""form-group"">
                            <label for=""basicInput"">تعداد قابل استفاده از تخفیف</label>
                            <span type=""text"" class=""form-control"" id=""Limitatio");
                WriteLiteral(@"nTimes""></span>
                        </fieldset>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <a class=""btn btn-secondary"" data-dismiss=""modal"">بستن</a>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedItemsDto<DiscountDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
