# hermes

<!-- badges -->

A monorepository containing the applications, services, and libraries that make up the __hermes__ product suite. The __hermes__ repository contains:
- An Single Page Application built with NextJS
- A mobile hybrid application build with React Native
- A REST API built with ASP.NET Core.

## GCP

| project name | project id |
| :----------- | :--------- |
| derrysmith-hermes-prd | derrysmith-hermes-prd-19750430 |
| derrysmith-hermes-dev | derrysmith-hermes-dev-19750430 |
| derrysmith-hermes-sbx | derrysmith-hermes-sbx-19750430 |


`derrysmith/hermes/server-api`

`derrysmith/hermes/client-web`

## installation

Instructions for how to build and run the three products locally.

### w/ Docker

```
$ docker compose ...
```

### w/ Visual Studio/VS Code

```
/-- derrysmith-hermes
	/-- client-api
	/-- client-web

	/-- mobile-api
	/-- mobile-app
		/-- anagrams
			/-- components
				|-- AnagramCard.tsx
				|-- AnagramList.tsx
			/-- screens
				|-- Anagrams.tsx
			/-- services
				|-- getAnagrams.ts
			|-- index.ts

	/-- server-api
```