	Pagination In Mvc Core 1.0 rc2 
	Using  Sakura.pagedList
Step 1

	Download package in Project.json

	    "Sakura.AspNetCore.PagedList": "1.0.2-rc2",
	    "Sakura.AspNetCore.Mvc.PagedList": "2.0.2-rc2",
	    "Microsoft.Extensions.DependencyInjection.Abstractions": "1.0.0-rc2-final",
	    "Microsoft.Extensions.Options.ConfigurationExtensions": "1.0.0-rc2-final"
Step 2
	Include  following code in Configure Services
        	public void ConfigureServices(IServiceCollection services)
	        {
        	    services.AddBootstrapPagerGenerator(options =>
	            {
        	        // Use default pager options.
                	options.ConfigureDefault();
	            });
        	    services.Configure<PagerOptions>(Configuration.GetSection("Pager"));
			…….
			………
		}
Step 3
      Include  Pager setting in  Appsetting .js

	"Pager": {
	    "ExpandPageItemsForCurrentPage": 2,
	    "PageItemsForEnding": 3,
	    "Layout": "Default",
	    "AdditionalSettings": {
	      "my-setting-one": "1"
	    },
	
	    "ItemOptions": {
	      "Default": {
	        "Content": "TextFormat:{0}",
	        "Link": "QueryName:page",
	        "InactiveBehavior": "Hide"
	       // "ActiveMode": "Alaways"
	      },
	      "GoToLastPage": {
	        "Content": "Text:Go To Last Page"
	      }
	    }
	  }
Step4
	Include  below Tag Helper in _ViewImports.cshtml
	@addTagHelper *, Sakura.AspNetCore.Mvc.PagedList

Step 5
	Controller
	using Sakura.AspNetCore;
       	
	public ActionResult Index(int? page, int? pageSize)
        {
            int no = page ?? 1;
            int size = pageSize ?? 2;
            var list = from c in _context.Product select c;
            IPagedList<Product> lst = null;
            lst = list.ToPagedList<Product>(size, no, null);

            return View(lst);
        }
	Index.cshtml
	  @model Sakura.AspNetCore.IPagedList<Pagination.Models.Product>
		<table>
			…
			…
			..
	
		</table>
        
            <ul class="pagination">
                <pager source="@Model" />
            </ul>


==========================================================================
Author :Mithun Poddar
Date:24th june,2016
Summary:Pagination In Asp.Net Mvc Core 1.0 RC2 using Sakura.PagedList
==========================================================================








