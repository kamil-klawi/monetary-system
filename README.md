# Monetary System

## Overview

A console-based monetary system written in **C#**, consisting of two main components:

- **Currency Library** – responsible for core logic such as currency modeling, management, validation, and conversion.
- **Console App** – simulates user interaction with wallets and transactions, providing a text-based interface to the system.

## Technologies Used

- **Language:** C#
- **Platform:** .NET (Console Application + Class Library)
- **Architecture:** Modular structure with separation of concerns

## Features

### Currency Library (`CurrencySystem.CurrencyLibrary`)
Handles all domain logic related to currency and conversion.

#### Currency Model:
  - Represents currencies with names, codes, and exchange rates

#### Currency Validation:
  - Ensures proper currency formatting and supported codes

#### Currency Management:
  - Allows creation and updating of currencies and exchange rates

#### Currency Conversion:
  - Converts amounts using fixed exchange rates

#### Custom Exceptions:
  - Provides meaningful error messages via domain-specific exceptions

---

### Console Application (`CurrencySystem.ConsoleApp`)
Implements user-facing logic through a command-line interface.

#### User, Wallet, and Transaction Models:
  - Represents users, their wallets (multi-currency), and financial operations

#### Validation:
  - Validates users, transactions, and wallet operations

#### Wallet Management:
  - Users can create and manage wallets, each with balances in different currencies

#### Balance Operations:
  - Add balance in a specific currency
  - Convert existing balance from one currency to another

---
