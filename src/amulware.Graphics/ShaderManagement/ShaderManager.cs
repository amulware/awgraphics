using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace amulware.Graphics.ShaderManagement
{
    public sealed partial class ShaderManager
    {
        private readonly Dictionary<ReloadableShader, string> shaderNames
            = new Dictionary<ReloadableShader, string>();

        private readonly Dictionary<ShaderType, Dictionary<string, ReloadableShader>> shaders
            = new Dictionary<ShaderType, Dictionary<string, ReloadableShader>>(3)
            {
                { ShaderType.VertexShader, new Dictionary<string, ReloadableShader>() },
                { ShaderType.GeometryShader, new Dictionary<string, ReloadableShader>() },
                { ShaderType.FragmentShader, new Dictionary<string, ReloadableShader>() },
            };

        private readonly Dictionary<string, ReloadableShaderProgram> programs
            = new Dictionary<string, ReloadableShaderProgram>();

        private readonly Dictionary<ReloadableShader, List<ReloadableShaderProgram>> programsByShader
            = new Dictionary<ReloadableShader, List<ReloadableShaderProgram>>();

        public ISurfaceShader this[string shaderProgramName]
        {
            get
            {
                programs.TryGetValue(shaderProgramName, out var program);
                return program;
            }
        }

        public void Add(ReloadableShaderProgram shaderProgram, string name)
        {
            if (programs.ContainsKey(name))
               throw new ArgumentException($"Tried adding shader program with name '{name} which is already taken.");
            
            // make sure all shaders can be added so in case of error our internal state stays valid
            var shadersToAdd = getUnknownShadersOfProgramAndFailOnNameCollision(shaderProgram, name);

            // add shaders we don't know yet
            foreach (var shader in shadersToAdd)
            {
                Add(shader, name);
            }

            programs.Add(name, shaderProgram);
            
            registerProgramForItsShaders(shaderProgram);
        }

        private List<ReloadableShader> getUnknownShadersOfProgramAndFailOnNameCollision(
            ReloadableShaderProgram shaderProgram, string name)
        {
            return shaderProgram.Shaders.Where(
                shader =>
                {
                    if (shaderNames.ContainsKey(shader))
                    {
                        return false;
                    }

                    var shadersOfType = shaders[shader.Type];
                    if (shadersOfType.ContainsKey(name))
                    {
                        throw new ArgumentException(
                            $"Tried adding unknown {shader.Type} under name '{name}', but name is already taken.");
                    }

                    return true;
                }
            ).ToList();
        }

        private void registerProgramForItsShaders(ReloadableShaderProgram shaderProgram)
        {
            foreach (var shader in shaderProgram.Shaders)
            {
                programsByShader.TryGetValue(shader, out var programs);
                if (programs == null)
                {
                    programs = new List<ReloadableShaderProgram>();
                    programsByShader.Add(shader, programs);
                }

                programs.Add(shaderProgram);
            }
        }

        public void Add(IEnumerable<ShaderFile> shaderFiles)
        {
            foreach (var file in shaderFiles)
            {
                Add(file);
            }
        }

        public void Add(ShaderFile shaderFile)
        {
            Add(shaderFile, shaderFile.FriendlyName);
        }

        public void Add(IShaderReloader shader, string name)
        {
            Add(new ReloadableShader(shader), name);
        }

        public void Add(ReloadableShader shader, string name)
        {
            if (shaderNames.ContainsKey(shader))
                throw new ArgumentException($"Shader already known by name '{shaderNames[shader]}'.");

            var shadersOfType = shaders[shader.Type];
            shadersOfType.Add(name, shader); // will throw if name already taken

            shaderNames.Add(shader, name);
        }

        private ReloadableShader getShader(ShaderType type, string shaderName)
        {
            shaders[type].TryGetValue(shaderName, out var shader);
            return shader;
        }
    }
}
