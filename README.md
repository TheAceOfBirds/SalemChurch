## SCP Code Assignment

Thanks for taking the time to complete this exercise. Below are some general requirements and guidelines
for how we would like it completed.

This is a basic .NET 8 MVC Project with not much in it yet. Bootstrap is installed by default when you create
a new project and I left that in. Feel free to use it, remove it, roll your own CSS and use another framework. 
It doesn't matter.

Gulp was added to process SASS and Javascript. Again, feel free to remove it, use it or ignore it.

##### Now, for the details.

Create a form of your choosing, either a contact us form, a "profile" edit form or something else,
that contains a variety of field types, i.e. text, email, drop down, checkboxes, and client side
and server side validation. 

A .NET MVC project comes with jQuery client side validation by default. I removed all of that.
You can add it back in, use the [aspnet-client-validation](https://www.npmjs.com/package/aspnet-client-validation) package,
or something else.

I'll let you decide how you want to do server side validation.

Utilize a [public api](https://github.com/public-api-lists/public-api-lists?tab=readme-ov-file) using either javascript or C# to build some aspect of your form.

Use dependency injection in some way.

When your form is submitted and valid, show a summary page. For bonus points, use a service
like [Railway](https://railway.app/) or [Azure](https://portal.azure.com/), or SQLite to save your form data,
but TempData is fine too.

Add any npm or nuget packages that you feel you need.

Please clone our repository and make your source code available to us.
