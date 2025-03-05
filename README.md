# DecisionDeck

## Overview
DecisionDeck is a poll app where users can vote on various topics. Only certain user types, such as admin, manager, and moderator, have specific permissions to manage polls and users.

## Features
- **User Voting:** All users can participate in voting on active polls.
- **Poll Creation:** Only admins and managers can create new polls.
- **User Management:** Admins can modify user details and permissions.
- **Group Management:** Admins can create groups and add users to these groups.
- **Poll Administration:** Admins and moderators can manage active and inactive polls, including editing and deleting polls.

## User Roles
- **Admin:** Full access to all features, including user and group management.
- **Manager:** Can create polls and manage polls they have created.
- **Moderator:** Can manage polls and moderate user activities.
- **User:** Can vote on polls and view results.

## Installation
1. Clone the repository:
   ```
   git clone https://github.com/yourusername/decisionDeck.git
   ```
2. Navigate to the project directory:
   ```
   cd decisionDeck
   ```
3. Install dependencies:
   ```
   dotnet restore
   ```
   
## Usage
1. Build the project:
   ```
   dotnet build
   ```

2. Start the application:
   ```
   dotnet run
   ```

3. Access the application in your web browser at http://localhost:5000.

## Contributing
1. Fork the repository.

2. Create a new branch for your feature or bugfix:
   ```
   git checkout -b feature-name
   ```

3. Commit your changes:
   ```
   git commit -m "Description of your changes"
   ```

4. Push to the branch:
   ```
   git push origin feature-name
   ```

5. Create a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For any questions or feedback, please contact [Shawn Fernandes] at [Shawnfeds88@outlook.com].
