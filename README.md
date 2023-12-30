# ReactDotNetBlog

ReactDotNetBlog is a full-stack modern blogging platform, combining the strengths of ReactJS and .NET Core. It not only offers a responsive and interactive frontend and a robust, scalable backend but also supports integration of interactive games and features developed with [Spline](https://app.spline.design/home), enhancing the user experience.

## Features

- **Dynamic React Frontend**: Engaging and responsive user interface.
- **.NET Core Backend**: High performance, security, and scalability.
- **Entity Framework Core**: Smooth and reliable data operations.
- **Rich Text Editor**: Advanced tools for content creation.
- **Customizable Themes**: Easily adjustable to match your style.
- **SEO Optimization**: Improved visibility for blog content.
- **Interactive Games with Spline**: Incorporate engaging and interactive 3D elements and games designed in Spline, bringing a unique dynamic to the blogging experience.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- Node.js
- .NET 5.0 SDK or later
- SQL Server or SQLite (as per your setup)

### Installing

A step-by-step series of examples that tell you how to get a development environment running.

#### Setting up the Backend

```bash
# Navigate to the backend directory
cd path/to/backend

# Restore .NET dependencies
dotnet restore

# Run database migrations
dotnet ef database update

# Start the backend server
dotnet run
