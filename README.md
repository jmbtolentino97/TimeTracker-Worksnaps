
# Time Tracker Helper (Worksnaps)

Time Tracker Helper (Worksnaps) is a lightweight C# application designed to simplify the process of tracking total worked hours and determining checkout times for employees using Worksnaps. Instead of navigating the Worksnaps website and waiting for pages to load, users can quickly access their work details with a simple shortcut.

## Key features
- **Quick Access:** Press `Ctrl + Alt + T` to bring up a form showing:
    - Total worked hours (excluding idle time).
    - The suggested checkout time based on the work schedule.
- **Automated Updates:** The application automatically retrieves data from the Worksnaps API every 5 minutes, ensuring close to accurate and up-to-date information.

## How It Works
- **API Integration:** Time Tracker Helper connects to the Worksnaps API to fetch work session data.
- **Data Processing:** The application calculates:
    - Total productive time (excluding idle periods).
    - Suggested checkout time based on predefined work hours.
- **User Interface:** The calculated information is displayed on a simple, intuitive form accessible via the keyboard shortcut.

## Getting Started
### Prerequisites
- .NET Core 8.0 SDK
- Access to the Worksnaps API (API key and credentials required)

### Installation
1. Clone the repository:
```bash
git clone https://github.com/jmbtolentino/TimeTracker-Worksnaps.git
```

2. Navigate to the project directory:
```bash
cd TimeTracker-Worksnaps
```

3. Build the project:
```bash
dotnet publish -c Release  -f net8.0-windows -r win-x64 --self-contained
```

4. Run TimeTracker-Worksnaps.exe located in the publish folder
```bash
cd TimeTracker-Worksnaps/bin/Release/net8.0-windows/win-x64/publish
```

## Usage
1. Launch the application.
2. Press `Ctrl + Alt + T` to display the form
3. Press `Ctrl + Alt + Shift + T` to terminate the application
4. View:
    - Total worked hours excluding idle time.
    - Suggested checkout time.

## Configuration
Ensure you have your Worksnaps API credentials set up in the application's configuration file placed in the root directory (e.g., appSettings.json):
```json
{
  "api_key": "",
  "project_id": "1111",
  "user_id": "123"
}
```

## Contribution
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature/bug fix:
```bash
git checkout -b feature-name
```
3. Commit your changes and push the branch
```bash
git push origin feature-name
```
4. Submit a pull request.

## License
This project is licensed under the MIT License.
