
# 🧠 Emotiv Performance Metrics Viewer (.NET MAUI)

This is a cross-platform application built with **.NET MAUI** targeting:

- `net8.0-android`  
- `net8.0-ios`  
- `net8.0-maccatalyst`

The application connects to the **Emotiv Launcher** using the **BCI-OSC** protocol (over **UDP**) to receive and display **real-time performance metrics** streamed from an Emotiv EEG headset. Metrics include focus, relaxation, excitement, stress, engagement, and interest.

---

## 📲 Platforms Supported

- Android  
- iOS  
- macOS (Catalyst)

> ✅ Requires .NET 8 and Visual Studio 2022+ with MAUI workload installed.

---

## 📦 Features

- Connects to Emotiv EEG headsets using BCI-OSC (UDP)  
- Receives and visualizes real-time **performance metrics**  
- Displays up-to-date values on screen  
- Supports mobile and desktop platforms using a single codebase  

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Windows or Mac) with:
  - **MAUI workload**
  - Android/iOS/MacCatalyst build tools
- An **Emotiv EEG headset** (EPOC X, Insight, EPOC+, etc.)  
- [Emotiv Launcher](https://www.emotiv.com/emotiv-launcher/) installed and logged in  
- **EmotivBCI App** launched from within Emotiv Launcher  
- **BCI-OSC** enabled with **Performance Metrics** streaming  

---

---

## 🛠 Configuration

If needed, modify the UDP listening IP or port in `UdpListener.cs`:

```csharp
const int port = 5000;
const string ip = "127.0.0.1"; // or your local network IP
```

Ensure that this matches the configuration in EmotivBCI's BCI-OSC settings.
---

## 🧪 Example Use Case

This app is useful for:

- Monitoring attention and engagement during learning  
- Measuring relaxation during meditation sessions  
- Displaying mental state in real-time for biofeedback or experiments  
---

## 🧠 Performance Metrics Explained

| Metric     | Description                                                  |
|------------|--------------------------------------------------------------|
| Engagement | Level of interest and immersion                              |
| Excitement | Arousal level — high excitement vs. calm state               |
| Stress     | Mental pressure or cognitive load                            |
| Relaxation | Calmness and mental ease                                     |
| Interest   | Curiosity or attraction to stimuli                           |
| Focus      | Concentration or attention on task                           |

---

## 🙌 Credits

- Developed by Giovani Florek (Giannnnnn)
- Powered by [Emotiv](https://www.emotiv.com/) technology  
- Uses [BCI-OSC](https://www.emotiv.com/products/bci-osc?srsltid=AfmBOop2mjjuIKIPzgQM-8hyCfkhiZKo8XRoh87X7wae_K30ezErLb8c) for data streaming  
