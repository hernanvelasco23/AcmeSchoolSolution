
This project is a proof of concept (PoC) for managing student enrollments in courses at ACMESchool. It allows:

Registering students (adults only). Registering courses. Enrolling students in courses after paymen. Retrieving a list of courses and their enrolled students based on a specified date range. The implementation is focused on creating a clean and scalable design with abstractions that will allow the system to evolve, integrating a real payment gateway and a database in the future.

Design Choices Domain-Driven Design The system models students, courses, and payments as part of the domain. Key domain classes include Student, Course, Money, and CoursePeriod. These encapsulate the core business logic.

Abstraction of Services The IPaymentGateway interface abstracts the payment process, allowing flexibility to swap the current mock implementation (PaymentGateway) with a real-world integration like Stripe or PayPal later.

The EnrollmentPolicy abstracts business rules, making the system adaptable to new rules in the future without modifying the enrollment service directly.

Clean Architecture We have divided the project into layers:

Domain: Contains business logic and domain models. Application: Contains the logic for enrolling students, payment processing, and enforcing business rules. Repositories: Abstracts data storage for students and courses. Currently, we use in-memory repositories, but these can be replaced with database-backed implementations later. Considerations for Future Development

Things I Would Have Liked to Do Persistence Layer: We have not integrated a database since it wasn't required for the PoC. In the future, adding database support with an ORM like Entity Framework would be necessary to persist students, courses, and enrollments. Real Payment Gateway Integration: The current implementation uses a mock payment gateway for simplicity. Later, we can integrate with real payment services

Things That Could Be Improved

Validation of Enrollment Process: The enrollment process currently assumes simple rules. It could be enhanced by adding support for other business rules, such as prerequisites for courses, limits on the number of enrollments per course, or discounts for certain students.

User Interface: There is no user interface as of now. In the future, we could build a web-based API using ASP.NET Core and a front-end for students to interact with the system.

Asynchronous Payment Processing: We could introduce asynchronous payment processing to handle situations where payments are pending or fail due to external issues. Third-Party Libraries Currently, the only external library used is Moq for unit testing. I chose Moq because it is lightweight and easy to use for mocking dependencies in unit tests.

In the future, we would likely use libraries such as:

Entity Framework: For database access and persistence. FluentValidation: For handling more complex validation rules. Payment Gateway SDKs: Depending on the payment service chosen (e.g., Stripe, PayPal, etc.). Time Invested and Research I invested approximately 8 hours in this project.
