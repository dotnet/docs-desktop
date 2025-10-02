# Add a Copilot highlight in the docs

Copilot is a powerful AI tool that speeds up and simplifies complex development tasks. By adding Copilot information to articles in various product and service areas, we can help customers take advantage of this new and powerful tool.  
This article provides instructions for identifying suitable articles, the types of scenarios we should target, and guidelines for crafting Copilot usage tips.

## What is a Copilot highlight?

A Copilot highlight is a section you add to an article that shows how to use Copilot to speed up or simplify the task that the article focuses on. It showcases a Copilot usage scenario and isn't a marketing pitch.

A Copilot highlight targeting a specific usage scenario includes:

- A descriptive section heading, such as "Use GitHub Copilot to serialize to JSON"
- A brief introduction explaining how Copilot can be applied to your scenario
- An example Copilot prompt formatted as a *Copilot-prompt* code block using the `copilot-prompt` value from the [Dev lang taxonomy](metadata-taxonomies/devlang.md).
- An optional Copilot output example
- Mandatory warning text for Copilot usage

For examples, see [Examples of published Copilot highlights](#examples-of-published-copilot-highlights).

## Identify potential articles

You can add a Copilot highlight to any article type, including conceptual and reference articles, but we believe procedural articles are a good place to start. Use this set of criteria to identify articles with the highest potential impact:

- **High traffic articles**: Prioritizing docs by page views help Copilot scenarios added here reach the most users.
- **Articles of topic type how-to, get-started, quickstart, or tutorial**: These content types lend themselves well to practical, actionable Copilot scenarios.
- **Articles with code snippets**: Scenarios involving Visual Studio/Visual Studio Code/Azure are good cases to show GitHub Copilot examples.
- **Articles that contain a scenario where Copilot can save developers time and effort on real world tasks**: See the [Identify helpful scenarios](#identify-helpful-scenarios) section that follows.

## Identify helpful scenarios

Page views and article types can help you find good candidates for a Copilot highlight, but the most important element is whether Copilot can provide meaningful value in the article. Look for articles where Copilot can save time and effort for real-world tasks.

Relevant Copilot usage scenarios are use cases that align with typical user workflows or areas where Copilot's suggestions would be useful. Through these examples, we have an opportunity to educate the user to take advantage of Copilot's capabilities in their regular workflow and enhance their productivity.

Some practical scenarios to show Copilot use:

- Generate customized code: Tell the reader to take the code provided in the how-to or quickstart and show them how to construct a prompt that modifies it for their specific scenario.
  For example:
  - Modify code to use a specific operating system or webserver or database
  - Generate language specific (for example, C#, C++, Python) or framework specific (for example, .NET, React) code

- Help with complex or detailed syntax.
  For example:
  - Translate a specific date and time to cron syntax for scheduling pipelines
  - Generate a specific regular expression

- Help with repetitive, mechanical tasks. These actions require planning, but implementing the idea is something that Copilot can speed up.
  For example:
  - Generate a class and its members
  - Take configuration information and generate a configuration file in a specific format
  - Refactor code to use a different API
  - Refactor code to target a different endpoint
  - Generate a YAML pipeline or GitHub Action that publishes the solution

- Help with troubleshooting.
  For example:
  - Use Copilot to debug an error


| **Recommended** | **Not recommended** |
| --- | --- |
| Use Copilot to generate serialization code for your specific objects.<br/><br/>*Why*: A prompt for this scenario shows how to generate custom code tailored to the user's specific task, unlike a static code example. | Ask Copilot about what specific code is doing.<br/><br/>*Why*: While interesting, a prompt for this scenario isn't specific to the article. It's generic guidance that belongs in a general "how to use copilot" article. |
| Use Copilot to migrate your specific `Newtonsoft.Json` code to `System.Text.Json`.<br/><br/>*Why*: A prompt for this scenario shows how to migrate user's custom code to use `System.Text.Json`, unlike a generic `System.Text.Json` code example. | Ask Copilot for instructions on how to do *XYZ*.<br/><br/>*Why*: A prompt for this scenario isn't specific to the article. It's generic guidance that belongs in a general "how to use copilot" article. |

## Determine which Copilot to use

Microsoft offers various ways to access Copilot: via the web, through Visual Studio, through Visual Studio Code, through the Azure portal, and more. And there are also plugins that can enhance these different flavors of Copilot.

- Don't refer to a specific type of Copilot unless the functionality you're describing is limited to that specific Copilot. For example, if a prompt works for all Copilot instances, don't qualify it. If the prompt or context only works for GitHub Copilot for Visual Studio, say so.
- List any special installation requirements for Copilot (such as requiring a specific plugin) in the first few sentences.

## Determine where to put the Copilot highlight

- Add Copilot highlights to an existing article. Avoid creating a separate article just for the highlight.
- Place the highlight with the task/scenario being used in the Copilot example. If it's generic in context of the article, it can be an H2 at the end of the article. If it fits within a workflow, it can be an H3 or H4 within a section.
- Consider calling attention to the highlight if it appears later in the article by adding a link to it as a *Tip* in the article intro.

## Copilot highlight structure

A Copilot highlight has a heading, instructions, a prompt, an optional output example, and a boilerplate warning about using AI-generated content: 

- **Section title**
  - Typical format:

   ````markdown
    ## Use AI to <accomplish a specific scenario>
    ````

    For example: 'Use AI to serialize a .NET object'.
  - Don't refer to Copilot in the section title, use the more generic "AI"
- **Instructions**
  - Provide a generalized prompt formula. If the formula contains placeholders, provide an example prompt.
  - Mention that the prompt uses Copilot, or a specific version of Copilot, but avoid mentioning Copilot more than once if possible.
- **Prompt**
  - Use the `copilot-prompt` devlang
  - Example:

    ````markdown
    ```copilot-prompt
       Take this code:
       <code example from article>
       And adapt it to use <detail 1> and <detail 2> and <detail 3>
    ```
    ````

- **Output example**
  - Don't show example output unless the prompt is complicated and contains placeholders. (The user can run the prompt themselves to see the output.)
- **Warning about AI-generated content**
  Include the following warning as plain text (not a note) after you show your prompt.

  ````markdown
  *Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot general use FAQs](https://aka.ms/copilot-general-use-faqs).*
  ````

## Writing guidelines

- Be concise and brief. Hopefully, we add many Copilot highlights to our docs. It's important that these sections are focused on a specific task and don't include redundant information.
  Avoid general guidelines and instructions about using Copilot, like explaining how prompts work. Other docs provide that information, which you can link to if you think the user needs them.
- Incorporate Copilot usage in the context of the article, rather than a generic example.
- Don't add gifs or screenshots to showcase the example scenario in action.
- Be sensitive about branding. Mention Copilot or the specific type of Copilot once in the introduction, but to keep the text friendly and avoid it coming across as marketing,  don't use the Copilot name repeatedly.
- Avoid marketing language. Copilot is an innovative new technology. Instead of talking about how cool and exciting it is, show its value by demonstrating its usefulness. Basically, avoid marketing language. For more information, see the [guidelines on marketing language](contribute-get-started-channel-guidance.md#unauthorized-content).

## Metadata requirements for highlights

Add the following metadata to your article with the Copilot highlight:

| Attribute | Value | Why? |
| --- | --- | --- |
| `ms.custom` | copilot-scenario-highlight | Helps identify docs updated with a copilot highlight |

## Templates

Here are some generic templates for adding a Copilot section to an existing article:

### Highlight template - Adapt code for your scenario

````markdown
## Use AI to customize the code for <scenario>

You can use AI tools, such as Copilot <or specific version of Copilot>, to customize the code in this article for your specific scenario <include specific information>.

```copilot-prompt
Take this code:
<code example from article>
And adapt it to use <detail 1> and <detail 2> and <detail 3>
```
  
Copilot is powered by AI, so surprises and mistakes are possible. For more information see Copilot FAQs.
````

### Highlight template - Accomplish a <task/scenario>

````markdown
## Use AI to accomplish <Task/Scenario>

You can use AI tools, such as Copilot  <or specific version of Copilot>, to <accomplish task/scenario>.
To generate code that <accomplishes task>, customize this prompt for your specific case <include specific information>.
    
```copilot-prompt
Example prompt that might contain placeholders that the user replaces with their information.
For example, generate a connection string that connects to a SQL server database with <address> that uses managed identity for authentication.
```

Copilot is powered by AI, so surprises and mistakes are possible. For more information, see Copilot FAQs.
````

## Examples of published Copilot highlights

| Article | Copilot section |
| --- | --- |
| [How to convert a string to a number](/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number) | [Use GitHub Copilot to convert a string to a number](/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number#use-github-copilot-to-convert-a-string-to-a-number) |
| [Split strings into substrings](/dotnet/csharp/how-to/parse-strings-using-split) | [Use GitHub Copilot to split a string](/dotnet/csharp/how-to/parse-strings-using-split#use-github-copilot-to-split-a-string) |
| [How to serialize JSON in C#](/dotnet/standard/serialization/system-text-json/how-to) | [Use GitHub Copilot to serialize to JSON](/dotnet/standard/serialization/system-text-json/how-to#use-github-copilot-to-serialize-to-json) |
| [Migrate from Newtonsoft.Json to System.Text.Json](/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft) | [Use GitHub Copilot to migrate](/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft#use-github-copilot-to-migrate) |
| [How to deserialize JSON in C#](/dotnet/standard/serialization/system-text-json/deserialization) | [Use GitHub Copilot to deserialize JSON](/dotnet/standard/serialization/system-text-json/deserialization#use-github-copilot-to-deserialize-json) |
| [How to customize property names and values with System.Text.Json](/dotnet/standard/serialization/system-text-json/customize-properties) | [Use GitHub Copilot to customize property names and order](/dotnet/standard/serialization/system-text-json/customize-properties#use-github-copilot-to-customize-property-names-and-order) |

## Questions

Use the [Copilot in the Docs chat channel](https://aka.ms/copilotindocsquestion) in Microsoft Teams for questions or feedback, and to share the highlights you add to your docs.

## Resources

- [How to write better prompts for GitHub Copilot](https://github.blog/developer-skills/github/how-to-write-better-prompts-for-github-copilot/)
- [Get better results with Copilot prompting](https://support.microsoft.com/en-us/topic/get-better-results-with-copilot-prompting-77251d6c-e162-479d-b398-9e46cf73da55)
- [Prompt engineering for GitHub Copilot](https://docs.github.com/en/copilot/using-github-copilot/prompt-engineering-for-github-copilot)
- [Learn about Copilot prompts](https://support.microsoft.com/en-us/topic/learn-about-copilot-prompts-f6c3b467-f07c-4db1-ae54-ffac96184dd5)
- [Cooking up a great prompt: Getting the most from Copilot](https://support.microsoft.com/en-us/topic/cooking-up-a-great-prompt-getting-the-most-from-copilot-7b614306-d5aa-4b62-8509-e46674a29165)
- [Craft effective prompts for Microsoft 365 Copilot](/training/paths/craft-effective-prompts-copilot-microsoft-365/)
- [GitHub Copilot Chat in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-chat)
- [GitHub Copilot in Visual Studio Code](https://code.visualstudio.com/docs/copilot/overview)
- [Copilot Chat Cookbook - GitHub Docs](https://docs.github.com/en/copilot/example-prompts-for-github-copilot-chat)