using BlazorExplorer.Domain.Subscriptions;
using BlazorExplorer.Domain.Topics;
using BlazorExplorer.Domain.Messages;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapGet("/Topics",  (ITopicService topicService, string connectionString) =>
{
    return topicService.GetTopicsAsync(connectionString);
})
.WithName("Topics");

app.MapGet("/Subscriptions", (ISubscriptionService subscriptionService, string connectionString, string topic) =>
{
    return subscriptionService.GetSubscriptionsAsync(connectionString, topic);
})
.WithName("Subscriptions");


app.MapGet("/Messages", (IMessageService messageService, string connectionString, string topic, string subscription) =>
{
    return messageService.PeekMessagesAsync(connectionString, topic, subscription);
})
.WithName("Messages");

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
//app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

