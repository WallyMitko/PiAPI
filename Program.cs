string filePath = "pi.txt";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Yep, it's working");
app.MapGet("/pi", (int digits) => {
	if (digits > 10000) {
		return "That's too many :/";
	}
	try {
		using var sr = new StreamReader(filePath);
		return sr.ReadToEnd()[..(digits + 1)];
	} catch (IOException) {
		return "Error reading file";
	}
});

app.Run();
