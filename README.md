<br />
<p align="center">

  <h3 align="center">Captain's Log</h3>

  <p align="center">
  <a href="https://github.com/izzettunc/captains-log">
    <img src="data/screenshots/logo.png" alt="Logo" width="80" height="80">
  </a>
  <br>
    A journaling application that encrypts your files and store them safely.
    <br />
    <br />
    <a href="https://github.com/izzettunc/captains-log/issues">Report Bug</a>
    ·
    <a href="https://github.com/izzettunc/captains-log/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
  * [Installation](#installation)
* [Usage](#usage)
  * [Data Storing Procedure](#data-storing-procedure)
* [Roadmap](#roadmap)
* [License](#license)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About The Project

I just want write some journal and made this project on a whim. But it's end up pretty nice and I want to share it.

**Features:**

* You can write journals that encrypted (So nobody can read it except you of course :smile:)
* You can search and filter your old journals
* Customizable text editor

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Installation

1.  Clone the repo
```sh
git clone https://github.com/izzettunc/captains-log.git
```
2. Open **Günlük Uygulaması.sln** with Visual Studio

3. Make changes, run it, use it whatever you like :smile:


<!-- USAGE EXAMPLES -->
## Usage

![Login Screen Shot][login-screenshot]

![Main Screen Shot][main-screenshot]

![Main Functions Screen Shot][mainfunc-screenshot]

![Functions Screen Shot][func-screenshot]

![Text Editor Screen Shot][texteditor-screenshot]

### Data Storing Procedure

I didn't bother using database because I was programming this to myself and was wanting to finish it asap.

```
 Data
  |
  |- Belongings (Where which user has which logs stored)
  |	  |
  |	  |-Encrypted Files
  |   ...
  |
  |- Logs (Where logs stored)
  |	  |
  |	  |-Encrypted Files
  |   ...
  |
  |- accounts (Where accounts stored)
  |	  
  |
  |- Encrypted Files (Account information)
  ...
```

<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/izzettunc/captains-log/issues) for a list of proposed features (and known issues).

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<!-- CONTACT -->
## Contact

İzzet Tunç - izzet.tunc1997@gmail.com
<br>
[![LinkedIn][linkedin-shield]][linkedin-url]

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/izzettunc
[main-screenshot]: data/screenshots/mainEcp.png
[login-screenshot]: data/screenshots/login.png
[func-screenshot]: data/screenshots/functions.png
[mainfunc-screenshot]: data/screenshots/mainFunc.png
[texteditor-screenshot]: data/screenshots/textEditor.png
