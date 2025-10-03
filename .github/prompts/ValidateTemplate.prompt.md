---
model: GPT-4o (copilot)
mode: agent
description: "Validates article structure against appropriate templates"
---

# Template Validation Prompt

You are tasked with validating that the current Markdown documentation file conforms to the appropriate article template from `/.github/projects/article-templates/`.

- **IMPORTANT**: Template files contain XML comments (`<!-- ... -->`) that provide crucial instructions. You must read and apply these instructions during validation.

## Validation Workflow

### Step 1: Identify Article Type
Analyze the current article to determine its type:
- Examine `ms.topic` frontmatter value
- Review content structure and purpose
- Consider file naming conventions
- Assess target audience and use case

### Step 2: Select and Read Template
- Map the article type to the corresponding template file:
  - `how-to` → `template-how-to-guide.md`
  - `quickstart` → `template-quickstart.md` 
  - `tutorial` → `template-tutorial.md`
  - `concept` → `template-concept.md`
  - `overview` → `template-overview.md`
  - `troubleshooting` → `general-troubleshoot.md`
  - Other types as defined in the templates directory
- Read the complete template file from `/.github/projects/article-templates/`
- Extract all template requirements and guidelines

### Step 3: Systematic Validation
Compare the current article against the template across all dimensions:

#### Frontmatter Analysis
- Check all required frontmatter fields
- Validate field values and formats
- Verify template-specific frontmatter requirements

#### Structure Validation
- Compare section presence and organization
- Verify heading hierarchy and naming
- Check for required content blocks

#### Content Pattern Compliance
- Analyze all headers format per template specifications
- Validate introduction patterns
- Check for template-mandated content elements

#### Consistency Verification
- Ensure title frontmatter aligns with H1 heading
- Verify internal consistency throughout the article
- Check template-specific formatting requirements

### Step 4: Generate Corrections
For any violations found:
- Reference the specific template requirement
- Provide the exact corrected version
- Explain the rationale based on template guidance
- Preserve the article's core content and intent

### Step 5: Next Steps and Related Content
- Validate if the article includes a **Next step** or **Related content** section at the end, as per the updated template style.
- If the article contains a **See also** section, ensure it is updated to **Related content** to align with the new guidelines.

## Execution Instructions

1. **Read the current article** completely
2. **Determine the article type** using the criteria above
3. **Load the appropriate template** from the templates directory
4. **Extract all template requirements** systematically
5. **Perform comprehensive comparison** across all elements
6. **Document violations** with specific template references
7. **Apply corrections** while maintaining content value

## Output Requirements

Provide a structured report including:
- **Article type identified** and reasoning
- **Template file used** for validation
- **Comprehensive violation list** with template citations
- **Specific corrections applied** with before/after examples
- **Summary of structural changes** made

## Validation Scope

This process should cover:
- All frontmatter requirements
- Complete structural conformance
- Heading and title formatting
- Required section presence
- Template-specific content patterns
- Internal consistency requirements

Focus on template fidelity while preserving the article's informational value and purpose.