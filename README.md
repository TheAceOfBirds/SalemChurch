## SCP Code Assignment

Thanks for taking the time to complete this exercise. Below are some general requirements and guidelines
for how we would like it completed. Add any npm or nuget packages that you feel you need to complete the assignment.

This is a basic .NET 8 MVC project without a whole lot in it. Bootstrap is installed by default when you create
a new project and I left that in. Feel free to use it, remove it, roll your own CSS or use another framework. 
It doesn't matter.

Gulp was added to process SASS and Javascript. Again, feel free to remove it, use it or ignore it.

##### Now, for the details.

1. Clone our repository.

2. Create a form of your choosing, either a contact us form, a "profile" edit form or something else,
that contains a variety of field types, i.e. text, email, drop down and checkboxes.

3. The form should have client side and server side validation. 

    A .NET MVC project comes with jQuery client side validation by default. I removed all of that.
You can add it back in, use the [aspnet-client-validation](https://www.npmjs.com/package/aspnet-client-validation) package,
or something else. I'll let you decide how you want to do server side validation.

5. Utilize a [public api](https://github.com/public-api-lists/public-api-lists?tab=readme-ov-file) using either javascript or C# to build some aspect of your form.

6. Use dependency injection in some way.

7. When your form is submitted and valid, show a summary page. For bonus points, use a service
like [Railway](https://railway.app/) or [Azure](https://portal.azure.com/), or SQLite to save your form data,
but TempData is fine too.

8. And finally, make your source code available to us.
