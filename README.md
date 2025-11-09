# SCADA System (C# .NET Framework)

This is a **demo SCADA Building Management System** developed in **C# WinForms (.NET Framework)**.
It was created as part of my **Bachelor’s thesis in Automation Engineering**, focusing on **real-time monitoring, control, and configuration** in industrial and IoT environments.

The project demonstrates how a standalone Windows-based SCADA system can integrate **real-time data acquisition**, **alarm handling**, **user access control**, and **MQTT communication** for distributed IoT devices — all built from the ground up without using external SCADA platforms.

---

## Background

This SCADA solution was developed as my **undergraduate thesis project** while studying for a **Bachelor’s degree in Automation Engineering**.
The goal was to design a modular, extensible, and low-cost building management SCADA platform that could:

- Operate **independently** without cloud or third-party services.
- Communicate with **LoRaWAN/MQTT** IoT gateways and devices.
- Provide an easy-to-use **Windows interface** for configuration and supervision.

---

## Features
- **Real-time tag monitoring and control**
  - Display and modify process values through a graphical HMI.
  - Supports both **digital** and **analog** signals.

- **Alarm management**
  - **Analog & Digital alarm handling** with priority levels and acknowledgment.
  - **Configurable alarms via XML file** (handled by the `HMI_Alarm` project).
  - **Alarm Configuration Form**: add, edit, and remove alarms from the system.
  - Visual and audible alarm indicators on the main SCADA screen.

- **User management**
  - User authentication and access level control.
  - **User Configuration Form** to add/edit/delete users.
  - Role-based restrictions for operations (e.g., operator vs. admin).

- **Tag management**
  - Centralized tag handling via XML configuration files.
  - **Tag Configuration Form** to add or modify tags used by the system.
  - Supports linking tags to alarms, trends, and MQTT communication.

- **Historical data logging & reporting**
  - Logs process data and alarms to SQL Server.
  - **Reporting interface** for viewing and exporting data history.
  - Trend charts and data grids for analysis.

- **Custom MQTT protocol**
  - Built on top of the **M2MQTT** library.
  - Extended for **SCADA-specific payload structure** and QoS handling.
  - Allows IoT device communication over local or cloud networks.

- **Tool utilities and reusable components**
  - Custom SCADA controls: lamps, motors, gauges, buttons, indicators, etc.
  - Shared tools for configuration, logging, and symbol management (`HMI_Tool` project).

- **System configuration**
  - All major settings (tags, alarms, users) stored in **XML** for portability.
  - Runtime configuration changes reflected without recompilation.

---

## Solution Structure
| Project | Description |
|----------|--------------|
| **DEMO** | Main WinForms application (runtime, dashboard, user interface) |
| **HMI_Alarm** | Alarm system logic, visualization, and configuration Forms |
| **HMI_Report** | Historical data management, trend charts, and report generation |
| **HMI_Tool** | Shared utilities, custom controls, and graphic symbols |
| **MQTT_Protocol** | Custom MQTT implementation for SCADA data exchange (based on M2MQTT) |
| **TagManagement** | Central tag database, configuration Form, XML serialization, and runtime access |

---

## Technology Stack
- **Language:** C# (.NET Framework)
- **UI Framework:** WinForms
- **Design Pattern:** MVVM (adapted for WinForms)
- **Communication:** MQTT (customized M2MQTT)
- **Database:** Microsoft SQL Server (optional file-based logging)
- **Configuration Files:** XML (tags, alarms, users, system settings)
- **Data Access:** LINQ
- **Reporting:** Grid & chart-based reporting system

---

## Demo video
https://youtu.be/FTkCNA2ay1k?si=9I4vv2DGahCT4bTq

---

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/Quirin176/MQTT_SCADA_Winform_DotNETFramework.git