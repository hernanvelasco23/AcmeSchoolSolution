# ACME School Course Management System

This project is a course management system for ACME School, designed to handle student registrations, course management, and payment processing. The implementation is in C# and is structured to allow for easy maintenance and potential future enhancements.

## Features

- Students can be registered by providing their name and age (only adults can register).
- Courses can be created with a name, registration fee, start and end dates, and a maximum number of students.
- Students can enroll in courses after paying the registration fee through a payment gateway.
- Retrieve a list of courses along with their enrolled students within a specified date range.

## Project Structure

- **EnrollmentStrategy**
  - EnrollmentPolicyStrategy: Implements the logic for enrollment policies.
  - IEnrollmentStrategy: Interface for enrollment strategies.
  - PaymentStrategy: Implements payment processing strategies.
- EnrollmentPolicy: Contains rules for student enrollment.
- EnrollmentService: Handles enrollment logic and interacts with strategies.
- IPaymentGateway: Defines the interface for payment gateway implementations.
- PaymentGateway: Implements the payment processing logic.
- Course: Represents a course with properties such as name, registration fee, and enrolled students.
- Student: Represents a student with properties like name and age.

## Design Choices

1. **Strategy Pattern**: 
   - The strategy pattern is used to encapsulate various enrollment policies and payment processing methods. This design allows for flexibility and easy extension of the enrollment rules and payment methods without modifying the core logic of the EnrollmentService.

2. **ReadOnly Collections**: 
   - The EnrolledStudents property is exposed as a read-only collection (IReadOnlyCollection<Student>) to prevent external modification of the internal list of enrolled students, maintaining the integrity of the course data.

3. **Validation**: 
   - Age validation is performed to ensure only adults can register. This logic is handled within the EnrollmentPolicyStrategy.

4. **Exception Handling**: 
   - Proper exception handling is implemented to manage scenarios such as enrolling a student in a full course or failing payment.

## Testing

The project includes an xUnit test project that automatically runs tests without requiring manual intervention. The tests cover:

- Valid student registration and course enrollment.
- Exception handling for underage students and failed payments.
- Validating the maximum capacity of courses.
- Ensuring that the properties of the Course and Student classes are correctly initialized.

### Things I Would Like to Improve

- **Database Integration**: Future work should include integrating a database to persist course and student information.
- **API Development**: Once the proof of concept is validated, developing a Web API for easier access to course management functionality should be prioritized.

### Third-Party Libraries Used

- **xUnit**: Used for testing the application logic.
- **Moq**: Used for creating mock objects in tests, allowing for better isolation of the tests.



I have invested approximately 6 hours in developing this project. Research was necessary for implementing the strategy pattern effectively, as well as understanding how to best handle money and course management concepts in C#. The use of IReadOnlyCollection was new to me.


