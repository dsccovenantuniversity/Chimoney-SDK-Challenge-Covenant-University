# Chimoney4j

Chimoney4j is a Java wrapper for <a href="https://chimoney.io">Chimoney</a>.

## Getting Started

- Register with <a href="https://chimoney.io">Chimoney</a>
- Request for API KEY from support
- set Your "CHIMONEY_API_KEY" environment variable
  You can use a .env file as shown below to set your API key

  ```env
  CHIMONEY_API_KEY = "YOUR API KEY"
  ```

## Installation

You need Maven installed with at least JDK 11. Download Maven <a href="https://maven.apache.org/download.cgi">here</a>

- Firstly, you need the JAR file

  - Clone this repo to your computer

  - In the root directory, run:

    ```
      mvn package
    ```

  - Copy the generated JAR file in `${project.basedir}/target` directory

  - Or you can head <a href="https://seyiadisa.github.io/chimoney">here</a> to download the JAR file.

- Run the following command:

```bash
mvn install:install-file -Dfile=/path/to/chimoney-1.0.jar -DgroupId=io.chimoney	-DartifactId=chimoney -Dversion=1.0 -Dpackaging=jar

```

- Then add the dependecy to your `pom.xml`

```xml
	<dependency>
		<groupId>io.chimoney</groupId>
		<artifactId>chimoney</artifactId>
		<version>1.0</version>
	</dependency>
```

Alternatively, you can tell the project to find the `.jar` in the system path like this:

```xml
	<dependency>
		<groupId>io.chimoney</groupId>
		<artifactId>chimoney</artifactId>
		<version>1.0</version>
		<scope>system</scope>
		<systemPath>/path/to/chimoney-1.0.jar</systemPath>
	</dependency>
```

## Usage

There are two ways you can set your API key.

- You can export it as an environment variable or create a `.env` file in the directory that contains your package (recommended)
- You can pass it as an argument when initialising chimoney

```java
import io.chimoney.chimoney.Chimoney;

// initialise without API key (recommended)
Chimoney chimoney = new Chimoney();

// initialise without API key
String API_KEY = "your_api_key";
Chimoney chimoney = new Chimoney(API_KEY);
```

You can also use the library in sandbox mode, but you will require a sandbox API key. You can read more about chimoney sandbox [here](https://chimoney.readme.io/reference/sandbox-environment)

```java
Chimoney chimoney = Chimoney.sandbox();
```

or

```java
String API_KEY = "your_api_key";
Chimoney chimoney = Chimoney.withSandbox(API_KEY);
```
