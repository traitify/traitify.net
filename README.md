traitify.net
============
Traitify is a .NET 4 wrapper for the Traitify Developer's API.

## Installation
Include the TraitifyLibrary in your Visual Studio solution.

##Usage

#### Config
```csharp
  Traitify traitify = new Traitify("https://api-domain.com", "--Your Public Key--", "--Secret Key--", "v1");
```

#### Create Assessment
```csharp
  String deck_id = "--Your Deck Id--";
  Assessment assessment = traitify.CreateAssessment(deck_id);
  Console.WriteLine("AssessmentId: " + assessment.id);
```

#### Get Assessment
```csharp
  String assessment_id = "--Your assessment Id--";
  Assessment assessment = traitify.GetAssessment(assessment_id);
  Console.WriteLine("AssessmentId: " + assessment.id);
```

#### Get Assessment Slides
```csharp
  String assessment_id = "--Your assessment Id--";
  List<Slide> slides = traitify.GetSlides(assessment_id);
  Console.WriteLine("SlideId: " + slides[0].id);
```

#### Set Assessment Slide
```csharp
  String assessment_id = "--Your assessment Id--";
  String slide_id = "--Your slide Id--";
  traitify.SetSlide(assessment_id, slide_id);
```

#### Get Assessment Personality Types
```csharp
  String assessment_id = "--Your assessment Id--";
  List<PersonalityType> personalityTypes = traitify.GetPersonalityTypes(assessment_id);
  Console.WriteLine("Type: " + personalityTypes[0].name);
```

#### Get Assessment Personality Traits
```csharp
  String assessment_id = "--Your assessment Id--";
  List<PersonalityTrait> personalityTraits = traitify.GetPersonalityTraits(assessment_id);
  Console.WriteLine("Trait: " + personalityTraits[0].name);
```

## Release History

* 0.1.0 Initial release

