# Note Taking App

This Note Taking App is a simple tool for keeping track of your thoughts and notes. 

The backend is developed with C# 8.0 using .NET Core Web API, and the frontend is crafted with Vue 3.0. 

The application stores data in a PostgreSQL database and both the frontend and backend are containerized with Docker, making deployment easy with `docker-compose`.

## Architecture

- **Backend**: C# 8.0 with .NET Core Web API
- **Frontend**: Vue 3.0
- **Database**: PostgreSQL
- **Containerization**: Docker for both frontend and backend
- **API Documentation**: Available at `http://localhost:8080/swagger/index.html` (local deployment)

## Deployment

The application can be deployed easily using Docker Compose. Make sure you have Docker and Docker Compose installed on your machine. Navigate to the project directory and run the following commands:

```bash
docker-compose build
docker-compose up
```
<img width="737" alt="image" src="https://github.com/gracemkuo/NoteTakingApp/assets/55439817/5d70d55f-e5ef-4fb1-bb35-04739fb33307">

## Frontend Usage
Available at `http://localhost/`
- **Writing Notes**: Simply enter your thoughts into the textarea.
- **Creating a New Note**: Click the write button to open a new blank textarea.
- **Notes Timeline**: Notes are recorded with timestamps and listed on the left side.
- **Deleting Notes**: Click the trash can button to delete a note.
- **Editing Notes**: Click on a timestamp to load the note in the textarea. After editing, the note will be saved with the new content.

## Database Schema
The PostgreSQL database stores the notes with the following schema:

1. ID: Unique identifier for each note.
2. Content: The text content of the note.
3. Creation Time: Timestamp for when the note was created.
4. Last Updated Time: Timestamp for the last update made to the note.
