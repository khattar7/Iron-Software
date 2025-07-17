# Iron-Software
# 📱 Old Phone Pad Text Decoder (C#)

This project simulates the behavior of old-style mobile phone text input using the multi-tap method. It interprets sequences of keypresses and converts them into readable text.

---

## 🔧 Features

- Supports digits 0–9 based on T9-style keypads
- Space (`' '`) separates key sequences
- Asterisk (`*`) functions as **backspace**
- Input must end with a hash (`#`) to process
- Custom character map for digit `1`: `&’(`

---

## 💻 Example

### Sample Input:
OldPhonePad(“33#”) => output: E
OldPhonePad(“227*#”) => output: B
OldPhonePad(“4433555 555666#”) => output: HELLO
OldPhonePad(“8 88777444666*664#”) => output: ?????


## 🧑‍💻 How to Run

### Requirements
- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (recommended)
- or [Mono](https://www.mono-project.com/) for Linux/macOS users

### Using .NET CLI
```bash
dotnet new console -n OldPhonePadApp
cd OldPhonePadApp
# Replace the generated Program.cs with the provided code
dotnet run
