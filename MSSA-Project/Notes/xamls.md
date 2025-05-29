# MainPage.xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
             x:Class="MSSA_Project.MainPage"
             Title="MSSA Study"
             BackgroundColor="Black">

    <ScrollView>
        <VerticalStackLayout Padding="10" Spacing="10">


            <!-- Dropdown to select card type -->
            <Picker x:Name="cardTypePicker"
                    Title="Select Card Type"
                    SelectedIndexChanged="OnCardTypeChanged"
                    TextColor="White">
                <Picker.Items>
                    <x:String>Project Overview</x:String>
                    <x:String>Assignment Cards</x:String>
                    <x:String>Method Problems</x:String>
                    <x:String>Syntax Problems</x:String>
                    <x:String>Whiteboard</x:String>
                </Picker.Items>
            </Picker>
            
            <Label x:Name="pageTitleLabel"
               Text="Assignment Title"
               FontSize="22"
               FontAttributes="Bold"
               TextColor="#B28DFF"
               LineBreakMode="WordWrap"
               HorizontalTextAlignment="Center"
               HorizontalOptions="Fill"
               Margin="0,10,0,0" />

            <!--
            <Button Text="Show Performance File Path"
                    Clicked="OnShowPathClicked"
                    BackgroundColor="DarkSlateGray"
                    TextColor="White"
                    Margin="0,10,0,0"
                    HorizontalOptions="Center"/> -->


            <!-- Top Navigation with centered card progress -->
            <Grid ColumnDefinitions="*,*,*" Padding="0,0,0,5">
                <Button Text="Previous"
                        Clicked="OnPreviousClicked"
                        HorizontalOptions="Start"
                        Grid.Column="0"
                        BackgroundColor="#B28DFF"
                        TextColor="Black"
                        Margin="0,20,0,0"/>

                <Button Text="View Performance Stats"
                        Clicked="OnStatsClicked"
                        HorizontalOptions="Center"
                        Grid.Column="1"
                        BackgroundColor="DarkSlateBlue"
                        TextColor="White"
                        Margin="0,20,0,0"/>

                <Button Text="Next"
                        Clicked="OnNextClicked"
                        HorizontalOptions="End"
                        Grid.Column="2"
                        BackgroundColor="#B28DFF"
                        TextColor="Black"
                        Margin="0,20,0,0"/>
            </Grid>

            <Label x:Name="feedbackLabel"
                   FontSize="14"
                   TextColor="Gray"
                   Grid.Column="1"
                   HorizontalOptions="Center" 
                   VerticalOptions="Center" />

            <!-- Mode + Review toggles in one row -->
            <Grid ColumnDefinitions="Auto,Auto,Auto,*,Auto,Auto,Auto" Padding="0,0,0,5" VerticalOptions="Center">

                <!-- Mode Group (wrapped in container for conditional visibility) -->
                <HorizontalStackLayout x:Name="modeSwitchContainer"
                           Grid.Column="0"
                           Spacing="4"
                           VerticalOptions="Center"
                           IsVisible="False">
                    <Label Text="Mode:" TextColor="White" VerticalOptions="Center" />
                    <Switch x:Name="modeSwitch"
                            Toggled="OnModeToggled"
                            OnColor="#B28DFF"
                            ThumbColor="Black"
                            VerticalOptions="Center" />
                    <Label x:Name="modeLabel"
                           Text="Method"
                           TextColor="White"
                           VerticalOptions="Center" />
                </HorizontalStackLayout>

                <!-- Spacer -->
                <ContentView Grid.Column="3" WidthRequest="1" />

                <!-- Review -->
                <Label Text="Review Incorrect:" TextColor="White" VerticalOptions="Center" HorizontalOptions="Start" Grid.Column="4" Margin="0,0,4,0" />
                <Switch x:Name="reviewSwitch"
                        Toggled="OnReviewToggled"
                        OnColor="Orange"
                        ThumbColor="Black"
                        Grid.Column="5"
                        VerticalOptions="Center"
                        Margin="0,0,4,0" />
                <Label x:Name="reviewFeedbackLabel"
                       Text=""
                       TextColor="Orange"
                       FontSize="12"
                       VerticalOptions="Center"
                       HorizontalOptions="End"
                       Grid.Column="5"
                       IsVisible="True" />

                <!-- Spacer -->
                <ContentView Grid.Column="6" WidthRequest="175" />

            </Grid>



            <!-- Prompt + Input Grid -->
            <Grid x:Name="promptGrid"
                  ColumnSpacing="20"
                  RowDefinitions="Auto,*"
                  Padding="10">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" /> <!-- Column 0 / left side : Prompt Area -->
                    <ColumnDefinition Width="*" /> <!-- Column 1 / right side : Prompt Area -->
                </Grid.ColumnDefinitions>

                <!-- Prompt Area -->
                <ScrollView Grid.Row="0" Grid.Column="0" 
                            x:Name="promptArea"
                            MaximumWidthRequest="500"
                            HorizontalOptions="FillAndExpand">
                    <VerticalStackLayout>
                        <Label x:Name="promptLabel"
                               Text="Prompt goes here"
                               FontSize="14"
                               FontFamily="Courier New"
                               LineBreakMode="WordWrap"
                               TextColor="White" />
                    </VerticalStackLayout>
                </ScrollView>

                <!-- Input Area -->
                <ScrollView Grid.Row="0" Grid.Column="1" 
                            x:Name="inputArea"
                            MaximumWidthRequest="600"
                            HorizontalOptions="FillAndExpand">
                    <VerticalStackLayout>
                        <Label Text="Your Answers:" 
                               FontAttributes="Bold" 
                               TextColor="White" />
                        <StackLayout x:Name="inputStack" />

                        <Button x:Name="submitButton"
                            Text="Submit"
                            Clicked="OnSubmitClicked"
                            WidthRequest="120"
                            HorizontalOptions="Center"
                                
                            Margin="0,10,0,0"
                            BackgroundColor="#B28DFF"
                            TextColor="Black" />

                        <Button x:Name="hintButton"
                            Text="Show Hint"
                            Clicked="OnHintClicked"
                            TextColor="White"
                            BackgroundColor="DarkSlateGray"
                            Padding="6"
                            FontSize="12"
                            HorizontalOptions="Start" />

                        <Label x:Name="hintLabel"
                            Text=""
                            TextColor="LightGray"
                            FontSize="12"
                            FontAttributes="Italic"
                            IsVisible="False"
                            LineBreakMode="WordWrap"
                            Margin="0,4,0,10"
                            MaxLines="6" />
                    </VerticalStackLayout>
                </ScrollView>

                <!-- Optional Video Row -->
                <WebView x:Name="videoPlayer"
                     Grid.Row="1"
                     Grid.ColumnSpan="2"
                     IsVisible="False"
                     HeightRequest="200"
                     BackgroundColor="Black"
                     Source="https://www.youtube.com/" />
            </Grid>


            <!-- Bottom Navigation -->
            <Grid ColumnDefinitions="*,*,*" Padding="0, 10, 0, 0">
                <Button Text="Previous"
                        Clicked="OnPreviousClicked"
                        HorizontalOptions="Start"
                        Grid.Column="0"
                        BackgroundColor="#B28DFF"
                        TextColor="Black"
                        Margin="0,20,0,0"/>

                <Button Text="Simulate Bot"
                        x:Name="botButton"
                        Clicked="OnRunBotClicked"
                        HorizontalOptions="Center"
                        Grid.Column="1"
                        BackgroundColor="DarkOliveGreen"
                        TextColor="White"
                        FontAttributes="Bold"
                        Margin="0,20,0,0"/>

                <Button Text="Next"
                        Clicked="OnNextClicked"
                        HorizontalOptions="End"
                        Grid.Column="2"
                        BackgroundColor="#B28DFF"
                        TextColor="Black"
                        Margin="0,20,0,0"/>
            </Grid>

        </VerticalStackLayout>
    </ScrollView>
</ContentPage>

# StatsPage.xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    x:Class="MSSA_Project.StatsPage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    Title="Performance Summary"
    BackgroundColor="Black">

    <ScrollView>
        <VerticalStackLayout Padding="20" Spacing="10">
            <Label Text="Card Performance Summary"
                   FontSize="24"
                   TextColor="White"
                   HorizontalOptions="Center" />

            <CollectionView x:Name="statsView">
                <CollectionView.ItemTemplate>
                    <DataTemplate>
                        <Frame BorderColor="SlateBlue"
                               BackgroundColor="#222"
                               CornerRadius="10"
                               Padding="10"
                               Margin="5">
                            <VerticalStackLayout>
                                <Label Text="{Binding CardId}" 
                                       FontSize="18" 
                                       TextColor="White"
                                       FontAttributes="Bold"/>
                                <Label Text="{Binding Mode, StringFormat='Mode: {0}'}"
                                       TextColor="MediumPurple"
                                       FontSize="14"/>
                                <Label Text="{Binding CardType, StringFormat='Type: {0}'}"
                                       TextColor="SlateBlue"
                                       FontSize="14"/>
                                <Label Text="{Binding CorrectRate}" 
                                       TextColor="LimeGreen"/>
                                <Label Text="{Binding Attempts, StringFormat='Attempts: {0}'}" 
                                       TextColor="LightGray"/>
                                <Label Text="{Binding FirstTryLabel, StringFormat='First Try: {0}'}"
                                       TextColor="LightSkyBlue"/>
                                <Label Text="{Binding LastAttempted, StringFormat='Last Attempt: {0}'}"
                                       TextColor="Gray" 
                                       FontSize="12"/>
                            </VerticalStackLayout>
                        </Frame>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>
            
            <Button Text="Back"
            Clicked="OnBackClicked"
            BackgroundColor="SlateGray"
            TextColor="White"
            Margin="0,5,0,0"
            HorizontalOptions="Center"
            WidthRequest="150"/>

        </VerticalStackLayout>
    </ScrollView>
</ContentPage>

# MSSA_Project.csproj
<Project Sdk="Microsoft.NET.Sdk">

	<PropertyGroup>
		<TargetFrameworks>net9.0-android;net9.0-ios;net9.0-maccatalyst</TargetFrameworks>
		<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net9.0-windows10.0.19041.0</TargetFrameworks>

		<OutputType>Exe</OutputType>
		<RootNamespace>MSSA_Project</RootNamespace>
		<AssemblyName>MSSA_Project</AssemblyName>
		<UseMaui>true</UseMaui>
		<SingleProject>true</SingleProject>
		<ImplicitUsings>enable</ImplicitUsings>
		<Nullable>enable</Nullable>

		<ApplicationTitle>MSSA Project</ApplicationTitle>
		<ApplicationId>com.companyname.mssaproject</ApplicationId>
		<ApplicationDisplayVersion>1.0</ApplicationDisplayVersion>
		<ApplicationVersion>1</ApplicationVersion>

		<WindowsPackageType>None</WindowsPackageType>

		<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'ios'">15.0</SupportedOSPlatformVersion>
		<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'maccatalyst'">15.0</SupportedOSPlatformVersion>
		<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'android'">21.0</SupportedOSPlatformVersion>
		<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</SupportedOSPlatformVersion>
		<TargetPlatformMinVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</TargetPlatformMinVersion>
		<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'tizen'">6.5</SupportedOSPlatformVersion>
	</PropertyGroup>

	<ItemGroup>
		<MauiIcon Include="Resources\AppIcon\appicon.svg" ForegroundFile="Resources\AppIcon\appiconfg.svg" Color="#512BD4" />
		<MauiSplashScreen Include="Resources\Splash\splash.svg" Color="#512BD4" BaseSize="128,128" />
		<MauiImage Include="Resources\Images\*" />
		<MauiImage Update="Resources\Images\dotnet_bot.png" Resize="True" BaseSize="300,185" />
		<MauiFont Include="Resources\Fonts\*" />
		<AndroidResource Remove="Staging\**" />
		<AndroidResource Remove="Validator\**" />
		<Compile Remove="Staging\**" />
		<Compile Remove="Validator\**" />
		<EmbeddedResource Remove="Staging\**" />
		<EmbeddedResource Remove="Validator\**" />
		<MauiCss Remove="Staging\**" />
		<MauiCss Remove="Validator\**" />
		<MauiXaml Remove="Staging\**" />
		<MauiXaml Remove="Validator\**" />
		<None Remove="Staging\**" />
		<None Remove="Validator\**" />
		<None Remove="Assets\RotateMatrixExample1.png" />
		<Content Include="Assets\RotateMatrixExample1.png">
		  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
		</Content>
		<MauiAsset Include="Resources\Raw\project.json" />
		<MauiAsset Include="Resources\Raw\Assignments.json" />
		<MauiAsset Include="Resources\Raw\methods.json" />
		<MauiAsset Include="Resources\Raw\methodCards.json" />
		<MauiAsset Include="Resources\Raw\syntax.json" />
		<MauiAsset Include="Resources\Raw\syntaxCards.json" />
		<MauiAsset Include="Resources\Raw\whiteboard.json" />
	</ItemGroup>

	<ItemGroup>
		<PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
		<PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="9.0.0" />
	</ItemGroup>

	<ItemGroup>
	  <MauiAsset Update="Resources\Raw\methods.json">
	    <CopyToOutputDirectory>Never</CopyToOutputDirectory>
	  </MauiAsset>
	</ItemGroup>

	<ItemGroup>
		<MauiXaml Update="MainPage.xaml">
			<CopyToOutputDirectory>Never</CopyToOutputDirectory>
		</MauiXaml>
		<Compile Update="MainPage.xaml.cs">
			<DependentUpon>MainPage.xaml</DependentUpon>
		</Compile>
	</ItemGroup>

	<ItemGroup>
		<MauiXaml Update="StatsPage.xaml">
			<Generator>MSBuild:Compile</Generator>
		</MauiXaml>
		<Compile Update="StatsPage.xaml.cs">
			<DependentUpon>StatsPage.xaml</DependentUpon>
		</Compile>
	</ItemGroup>

	
</Project>
