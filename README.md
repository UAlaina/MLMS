# Modern Library Management System

## Overview

The Modern Library Management System (MLMS) is a simple desktop application designed to manage various aspects of a library, including book addition, member management, issuing books, and processing payments. The system allows administrators to manage the library's inventory, issue books to members, and receive payments for services.

## Features

- **Add Books**: Allows administrators to add new books to the library with details like title, author, ISBN, and more.
- **Add Members**: Allows administrators to register new members with essential details like name, email, and phone number.
- **Issue Books**: Enables the issuance of books to members, including issuing dates and due dates, and tracks the status of the books.
- **Payment System**: Supports different payment methods (Credit Card, PayPal) and records payments for issued books.
- **Database Integration**: All data is stored in a relational SQL database, including books, members, issued books, and payments.

## Table Structure

### Book Table
```sql
CREATE TABLE [dbo].[Book] (
    [BookId] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR(255) NOT NULL,
    [Author] NVARCHAR(100) NOT NULL,
    [ISBN] NVARCHAR(20) NOT NULL,
    [Publisher] NVARCHAR(100) NULL,
    [YearPublished] INT NULL,
    [Quantity] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([BookId] ASC)
);

CREATE TABLE [dbo].[Member] (
    [MemberId] INT IDENTITY (1, 1) NOT NULL,
    [FullName] NVARCHAR (100) NOT NULL,
    [Address] NVARCHAR (500) NULL,
    [DOB] DATE NULL,
    [PhoneNumber] NVARCHAR (15) NULL,
    [Email] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([MemberId] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);


CREATE TABLE [dbo].[IssueBooks] (
    [IssueID] INT IDENTITY (1, 1) NOT NULL,
    [MemberID] INT NOT NULL,
    [BookID] INT NOT NULL,
    [IssueBookName] NVARCHAR (255) NOT NULL,
    [ISBN] NVARCHAR (20) NOT NULL,
    [Author] NVARCHAR (100) NOT NULL,
    [IssueDate] DATE DEFAULT (getdate()) NULL,
    [DueDate] DATE NULL,
    [Status] VARCHAR (50) DEFAULT ('Issued') NULL,
    PRIMARY KEY CLUSTERED ([IssueID] ASC),
    FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Member] ([MemberId]),
    FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book] ([BookId])
);

CREATE TABLE [dbo].[Payment] (
    [PaymentID] INT IDENTITY (1, 1) NOT NULL,
    [MemberID] INT NOT NULL,
    [PaymentMethod] VARCHAR (50) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    [Email] NVARCHAR (255) NOT NULL,
    [CardNumber] VARCHAR (16) NULL,
    [ExpireDate] DATE NULL,
    [SecurityCode] VARCHAR (4) NULL,
    [Amount] DECIMAL (10, 2) NOT NULL,
    [PaymentDate] DATE DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([PaymentID] ASC),
    FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Member] ([MemberId])
);

```

## Getting Started

### Prerequisites

To run the Library Management System, ensure you have the following:

- **Visual Studio** or any C# IDE of your choice.
- **SQL Server** or **SQL Server Express** (for local database usage).
- **SQL Server Management Studio (SSMS)** (optional for database management).

## Usage

### Add Books:
1. Click the Add Book button.
2. Fill in the book details such as name, author, ISBN, and quantity.
3. Click Save to add the book to the library catalog.


## Add Members:
1. Click the Add Member button.
2. Fill in the member’s personal details including name, address, phone number, and email.
3. Click Save to register the new member.
4. Issue Books:
5. Select a member and a book to issue.
6. Set the issue date and due date for the book.
7. Track the status of the book (e.g., "Issued").
8. Click Issue Book to confirm the issuance.

## Process Payment:
1. Select a member to process payment.
2. Enter payment details, including payment method (Credit Card or PayPal), amount, and other payment info (e.g., card number, expiry date).
3. Click Pay Now to process the payment and store the transaction in the database.


### License
This project is licensed under the MIT License - see the LICENSE file for details.
