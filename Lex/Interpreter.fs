﻿module Interpreter
open AST
open Reader
open GlobalVariable
open Parser

let mutable startLine = 0
let mutable finalReturnValue = 0
let mutable finishProgram = false
let mutable resetInterprete = false

let interpreteAst (ast: Ast list) = 
    let rec interprete (ast: Ast list) = 
        if not resetInterprete then   
            match ast with
            | [] -> ()
            // condition
            | (IF (cond, ast)) :: rest -> 
                let (var, value) = cond
                if getVariable(var) = value then
                    interprete ast 
                    interprete rest
                else
                    interprete rest 
            | (IFNOT (cond, ast)) :: rest -> 
                let (var, value) = cond
                if getVariable(var) <> value then
                    interprete ast 
                    interprete rest
                else
                    interprete rest 

            // variable
            | (ASSIGN (ASSIGN_VALUE (var, value))) :: rest ->    
                setVariable var value
                interprete rest 
            | (ASSIGN (ASSIGN_VARIABLE (var, value))) :: rest -> 
                let realvalue = getVariable value
                setVariable var realvalue
                interprete rest
            | (OPERATOR (DEATH, var)) :: rest -> 
                let value = getVariable var
                setVariable var (value + 1)
                interprete rest
            | (CONSOLEOUT (VARIABLE var)) :: rest ->
                let value = getVariable var
                printfn "%A" value
                interprete rest
            | (CONSOLEOUT (REFLECTION (refType, var))) :: rest ->
                match refType with
                | NAMESPACE -> printfn "%A" (getNamespace var)
                | HISTORY -> printfn "%A" (getVariableHistory var)
                interprete rest
            // flow
            | (BREAK) :: rest -> 
                ()
            | (GOTO (line)) :: rest -> 
                startLine <- line
                resetInterprete  <- true
                ()
            | (RETURN (var)) :: rest -> 
                finishProgram  <- true
                finalReturnValue <- getVariable var
                
            // nothing
            | _ :: rest -> 
                interprete rest
    interprete ast 

let run (path : string) =

    let code = loadCode path
    startLine <- 0
    finalReturnValue <- 0
    finishProgram <- false
    resetInterprete <- false
    while not finishProgram do
        let codeStart = List.skip startLine code
        if codeStart.Head.Depth <> 0 then
            printfn "Error: Code is not valid"
            finishProgram <- true
        else 
            let ast = parse codeStart
            interpreteAst ast
       
        if resetInterprete then
            resetInterprete <- false
        else
            finishProgram <- true
    finalReturnValue
