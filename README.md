
# 🗓️ SyncItUp: Cross-Timezone Meeting Scheduler

## Overview

This project is a meeting scheduling application developed for the **HackUNT Hackathon**. The application allows users to create, view, and manage meetings across different time zones. Users can create meetings, invite participants, and view meeting times adjusted for their local timezone. By automating timezone conversions, this tool provides a seamless scheduling experience, ensuring that users never have to manually calculate meeting times or worry about timezone errors.

## Why This Tool is Useful

Scheduling meetings across time zones can be challenging and error-prone, especially for globally distributed teams. This application automates timezone conversion, enabling users to create, view, and join meetings without worrying about timezone discrepancies. By handling time conversions automatically, the tool ensures that all users see meeting times in their local timezone, making scheduling and participation easier and more reliable.

## 🤝 Collaborators

This project was developed collaboratively by the following team members for the **HackUNT Hackathon**:

- **Aseel Shaheen** - [GitHub](https://github.com/Aseel-Sh)
- **Kyilee Bell** - [GitHub](https://github.com/kyibell)
- **Marcelo Gonzales** - [GitHub](https://github.com/Marcelo-Gzz)
- **Juan Correa** - [GitHub](https://github.com/juancorrea50)

## Features

### 🔐 User Management
- **User Registration and Login**: Secure registration and login functionalities.
- **Profile Management**: Users can update their profile, including uploading profile pictures and managing personal details.
- **Role-Based Access Control**: Different user roles (e.g., User, Manager) have different permissions.

### 📅 Meeting Scheduling
- **Create Meetings**: Users can create meetings, specifying the title, description, start time, and end time.
- **Participant Invitations**: Users can invite other users to join meetings as participants.
- **Time Zone Detection and Conversion**: The application detects the user's timezone and adjusts meeting times accordingly. Meeting times are stored in UTC in the backend for consistency and are converted to each participant’s local time before display.
- **View All Meetings by User**: Users can view a list of all meetings they have created or are invited to, with times displayed in their local timezone.

### 📬 Response Model
- **Consistent API Responses**: All API endpoints follow a standardized response model, including `Status`, `Message`, `Data`, and error handling fields, making it easier for the frontend to handle responses and display user-friendly messages.

### ⚙️ Architecture

The project follows a **three-tier architecture** for better separation of concerns and maintainability:

- **Presentation Layer**
  - **Frontend (React)**: Built with **React** for a modern, responsive user interface. The frontend automatically detects the user's timezone using JavaScript and passes it to the backend for accurate time conversion.
  - **Backend Presentation Layer (ASP.NET Core Controllers)**: The controllers handle HTTP requests, validate inputs, and call the appropriate service layer methods. They standardize responses using a consistent API response model, making it easier for the frontend to consume data.

- **Service Layer**
  - Contains business logic for creating meetings, inviting participants, managing user roles, and handling timezone conversions.
  - Validates data and coordinates interactions between the presentation and data access layers, ensuring that only valid data reaches the database.

- **Data Access Layer**
  - Uses Entity Framework Core to manage data persistence for users, meetings, and attachments.
  - Handles CRUD operations and interacts directly with the database, keeping the rest of the application abstracted from low-level data operations.

### 🚨 Error Handling
- **Detailed Error Responses**: API responses include structured error messages for easier debugging on the frontend, such as invalid timezone errors or missing user data.

## 🚀 Future Enhancements

If we had more time, we would consider adding the following features:

- **In-App Meeting Attendance**:
  - Allow users to join meetings directly within the application, potentially with integrated video or audio functionality.

- **Calendar View for Meetings**:
  - Provide a calendar view where users can easily see all scheduled meetings, view details, and manage their schedule.

- **Logging and Monitoring**:
  - Implement structured logging with log levels (e.g., `Debug`, `Info`, `Error`) to track critical actions and diagnose issues.

- **Enhanced Role-Based Access Control (RBAC)**:
  - Add more granular role-based pages and permissions, enabling finer control over which roles can access and modify different resources within the application.

- **Audit Trails**:
  - Add audit logs to track all CRUD operations, such as meeting creation, user profile updates, and participant invitations, to ensure accountability.

- **Notifications System**:
  - Implement email or in-app notifications to inform participants about upcoming meetings, new meeting invitations, and meeting updates.

- **Recurring Meetings**:
  - Add support for recurring meetings with customizable schedules (daily, weekly, monthly) and automatic scheduling.

- **Enhanced Timezone Support and Localization**:
  - Allow users to select preferred date and time formats based on their locale, making the app more user-friendly globally.

- **Comprehensive Testing**:
  - Increase test coverage with unit tests to ensure reliability.

- **User Activity Tracking**:
  - Implement activity tracking to monitor user engagement, providing insights into user behavior and feature usage.

---
