require 'rubygems'
gem 'albacore', '0.2.5'
require 'albacore'
require 'date'

CONFIGURATION = ENV['CONFIGURATION'] || 'Release'

task :default => [:compile]
task :ci => [:compile]

msbuild :compile => [:version] do |msb|
  msb.solution = "NQUnit.sln"
  msb.targets :Rebuild
  msb.command = File.join ENV['WINDIR'], 'Microsoft.NET', 'Framework', 'v4.0.30319', 'msbuild.exe'
  msb.properties :configuration => CONFIGURATION
end

def load_version 
  base_build_number = "0.0.0"
  File.open('VERSION.txt', 'r') do |f|
    base_build_number = f.gets.chomp
  end
  base_build_number
end

BASE_VERSION = load_version

desc "Update the version information for the build"
assemblyinfo :version do |asm|
  asm_version = BASE_VERSION + ".0"
  begin
    commit = `git log -1 --pretty=format:%H`
  rescue
    commit = "git unavailable"
  end
  ci_build = ENV['BUILD_NUMBER'] || '0'
  build_version = "#{BASE_VERSION}.#{ci_build}"
  puts "Version: #{build_version}"
  asm.trademark = commit
  asm.product_name = "NQUnit"
  asm.version = build_version
  asm.file_version = build_version
  asm.custom_attributes :AssemblyInformationalVersion => build_version
  asm.copyright = "Copyright 2010-#{Date.today.year} Robert Moore, Miguel Madero"
  asm.output_file = "CommonAssemblyInfo.cs"
end
