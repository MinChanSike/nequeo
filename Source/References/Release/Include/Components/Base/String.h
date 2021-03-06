/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2014 http://www.nequeo.com.au/
*
*  File :          String.h
*  Purpose :       String class.
*
*/

/*
Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/

#pragma once

#ifndef _STRING_H
#define _STRING_H

#include "Global.h"
#include "Ascii.h"
#include <cstring>

namespace Nequeo
{
	/// <summary>
	/// Provides methods and properties used for string mainipulation.
	/// </summary>
	class StringEx
	{
	public:
		StringEx();
		~StringEx();

		/// <summary>
		/// Convert from wide string to string.
		/// </summary>
		/// <param name="wstr">The wide string.</param>
		/// <returns>The string.</returns>
		std::string WideStringToString(std::wstring wstr);

		/// <summary>
		/// Convert from string to wide string.
		/// </summary>
		/// <param name="str">The string.</param>
		/// <returns>The wide string.</returns>
		std::wstring StringToWideString(std::string str);

	private:
		bool _disposed;
	};


	template <class S>
	S trimLeft(const S& str)
		/// Returns a copy of str with all leading
		/// whitespace removed.
	{
		typename S::const_iterator it = str.begin();
		typename S::const_iterator end = str.end();

		while (it != end && Ascii::isSpace(*it)) ++it;
		return S(it, end);
	}


	template <class S>
	S& trimLeftInPlace(S& str)
		/// Removes all leading whitespace in str.
	{
		typename S::iterator it = str.begin();
		typename S::iterator end = str.end();

		while (it != end && Ascii::isSpace(*it)) ++it;
		str.erase(str.begin(), it);
		return str;
	}


	template <class S>
	S trimRight(const S& str)
		/// Returns a copy of str with all trailing
		/// whitespace removed.
	{
		int pos = int(str.size()) - 1;

		while (pos >= 0 && Ascii::isSpace(str[pos])) --pos;
		return S(str, 0, pos + 1);
	}


	template <class S>
	S& trimRightInPlace(S& str)
		/// Removes all trailing whitespace in str.
	{
		int pos = int(str.size()) - 1;

		while (pos >= 0 && Ascii::isSpace(str[pos])) --pos;
		str.resize(pos + 1);

		return str;
	}


	template <class S>
	S trim(const S& str)
		/// Returns a copy of str with all leading and
		/// trailing whitespace removed.
	{
		int first = 0;
		int last = int(str.size()) - 1;

		while (first <= last && Ascii::isSpace(str[first])) ++first;
		while (last >= first && Ascii::isSpace(str[last])) --last;

		return S(str, first, last - first + 1);
	}


	template <class S>
	S& trimInPlace(S& str)
		/// Removes all leading and trailing whitespace in str.
	{
		int first = 0;
		int last = int(str.size()) - 1;

		while (first <= last && Ascii::isSpace(str[first])) ++first;
		while (last >= first && Ascii::isSpace(str[last])) --last;

		str.resize(last + 1);
		str.erase(0, first);

		return str;
	}


	template <class S>
	S toUpper(const S& str)
		/// Returns a copy of str containing all upper-case characters.
	{
		typename S::const_iterator it = str.begin();
		typename S::const_iterator end = str.end();

		S result;
		result.reserve(str.size());
		while (it != end) result += Ascii::toUpper(*it++);
		return result;
	}


	template <class S>
	S& toUpperInPlace(S& str)
		/// Replaces all characters in str with their upper-case counterparts.
	{
		typename S::iterator it = str.begin();
		typename S::iterator end = str.end();

		while (it != end) { *it = Ascii::toUpper(*it); ++it; }
		return str;
	}


	template <class S>
	S toLower(const S& str)
		/// Returns a copy of str containing all lower-case characters.
	{
		typename S::const_iterator it = str.begin();
		typename S::const_iterator end = str.end();

		S result;
		result.reserve(str.size());
		while (it != end) result += Ascii::toLower(*it++);
		return result;
	}


	template <class S>
	S& toLowerInPlace(S& str)
		/// Replaces all characters in str with their lower-case counterparts.
	{
		typename S::iterator it = str.begin();
		typename S::iterator end = str.end();

		while (it != end) { *it = Ascii::toLower(*it); ++it; }
		return str;
	}


#if !defined(NEQUEO_NO_TEMPLATE_ICOMPARE)


	template <class S, class It>
	int icompare(
		const S& str,
		typename S::size_type pos,
		typename S::size_type n,
		It it2,
		It end2)
		/// Case-insensitive string comparison
	{
		typename S::size_type sz = str.size();
		if (pos > sz) pos = sz;
		if (pos + n > sz) n = sz - pos;
		It it1 = str.begin() + pos;
		It end1 = str.begin() + pos + n;
		while (it1 != end1 && it2 != end2)
		{
			typename S::value_type c1(Ascii::toLower(*it1));
			typename S::value_type c2(Ascii::toLower(*it2));
			if (c1 < c2)
				return -1;
			else if (c1 > c2)
				return 1;
			++it1; ++it2;
		}

		if (it1 == end1)
			return it2 == end2 ? 0 : -1;
		else
			return 1;
	}


	template <class S>
	int icompare(const S& str1, const S& str2)
		// A special optimization for an often used case.
	{
		typename S::const_iterator it1(str1.begin());
		typename S::const_iterator end1(str1.end());
		typename S::const_iterator it2(str2.begin());
		typename S::const_iterator end2(str2.end());
		while (it1 != end1 && it2 != end2)
		{
			typename S::value_type c1(Ascii::toLower(*it1));
			typename S::value_type c2(Ascii::toLower(*it2));
			if (c1 < c2)
				return -1;
			else if (c1 > c2)
				return 1;
			++it1; ++it2;
		}

		if (it1 == end1)
			return it2 == end2 ? 0 : -1;
		else
			return 1;
	}


	template <class S>
	int icompare(const S& str1, typename S::size_type n1, const S& str2, typename S::size_type n2)
	{
		if (n2 > str2.size()) n2 = str2.size();
		return icompare(str1, 0, n1, str2.begin(), str2.begin() + n2);
	}


	template <class S>
	int icompare(const S& str1, typename S::size_type n, const S& str2)
	{
		if (n > str2.size()) n = str2.size();
		return icompare(str1, 0, n, str2.begin(), str2.begin() + n);
	}


	template <class S>
	int icompare(const S& str1, typename S::size_type pos, typename S::size_type n, const S& str2)
	{
		return icompare(str1, pos, n, str2.begin(), str2.end());
	}


	template <class S>
	int icompare(
		const S& str1,
		typename S::size_type pos1,
		typename S::size_type n1,
		const S& str2,
		typename S::size_type pos2,
		typename S::size_type n2)
	{
		typename S::size_type sz2 = str2.size();
		if (pos2 > sz2) pos2 = sz2;
		if (pos2 + n2 > sz2) n2 = sz2 - pos2;
		return icompare(str1, pos1, n1, str2.begin() + pos2, str2.begin() + pos2 + n2);
	}


	template <class S>
	int icompare(
		const S& str1,
		typename S::size_type pos1,
		typename S::size_type n,
		const S& str2,
		typename S::size_type pos2)
	{
		typename S::size_type sz2 = str2.size();
		if (pos2 > sz2) pos2 = sz2;
		if (pos2 + n > sz2) n = sz2 - pos2;
		return icompare(str1, pos1, n, str2.begin() + pos2, str2.begin() + pos2 + n);
	}


	template <class S>
	int icompare(
		const S& str,
		typename S::size_type pos,
		typename S::size_type n,
		const typename S::value_type* ptr)
	{
		typename S::size_type sz = str.size();
		if (pos > sz) pos = sz;
		if (pos + n > sz) n = sz - pos;
		typename S::const_iterator it = str.begin() + pos;
		typename S::const_iterator end = str.begin() + pos + n;
		while (it != end && *ptr)
		{
			typename S::value_type c1(Ascii::toLower(*it));
			typename S::value_type c2(Ascii::toLower(*ptr));
			if (c1 < c2)
				return -1;
			else if (c1 > c2)
				return 1;
			++it; ++ptr;
		}

		if (it == end)
			return *ptr == 0 ? 0 : -1;
		else
			return 1;
	}


	template <class S>
	int icompare(
		const S& str,
		typename S::size_type pos,
		const typename S::value_type* ptr)
	{
		return icompare(str, pos, str.size() - pos, ptr);
	}


	template <class S>
	int icompare(
		const S& str,
		const typename S::value_type* ptr)
	{
		return icompare(str, 0, str.size(), ptr);
	}


#else


	int icompare(const std::string& str, std::string::size_type pos, std::string::size_type n, std::string::const_iterator it2, std::string::const_iterator end2);
	int icompare(const std::string& str1, const std::string& str2);
	int icompare(const std::string& str1, std::string::size_type n1, const std::string& str2, std::string::size_type n2);
	int icompare(const std::string& str1, std::string::size_type n, const std::string& str2);
	int icompare(const std::string& str1, std::string::size_type pos, std::string::size_type n, const std::string& str2);
	int icompare(const std::string& str1, std::string::size_type pos1, std::string::size_type n1, const std::string& str2, std::string::size_type pos2, std::string::size_type n2);
	int icompare(const std::string& str1, std::string::size_type pos1, std::string::size_type n, const std::string& str2, std::string::size_type pos2);
	int icompare(const std::string& str, std::string::size_type pos, std::string::size_type n, const std::string::value_type* ptr);
	int icompare(const std::string& str, std::string::size_type pos, const std::string::value_type* ptr);
	int icompare(const std::string& str, const std::string::value_type* ptr);


#endif


	template <class S>
	S translate(const S& str, const S& from, const S& to)
		/// Returns a copy of str with all characters in
		/// from replaced by the corresponding (by position)
		/// characters in to. If there is no corresponding
		/// character in to, the character is removed from
		/// the copy. 
	{
		S result;
		result.reserve(str.size());
		typename S::const_iterator it = str.begin();
		typename S::const_iterator end = str.end();
		typename S::size_type toSize = to.size();
		while (it != end)
		{
			typename S::size_type pos = from.find(*it);
			if (pos == S::npos)
			{
				result += *it;
			}
			else
			{
				if (pos < toSize) result += to[pos];
			}
			++it;
		}
		return result;
	}


	template <class S>
	S translate(const S& str, const typename S::value_type* from, const typename S::value_type* to)
	{
		return translate(str, S(from), S(to));
	}


	template <class S>
	S& translateInPlace(S& str, const S& from, const S& to)
		/// Replaces in str all occurences of characters in from
		/// with the corresponding (by position) characters in to.
		/// If there is no corresponding character, the character
		/// is removed.
	{
		str = translate(str, from, to);
		return str;
	}


	template <class S>
	S translateInPlace(S& str, const typename S::value_type* from, const typename S::value_type* to)
	{
		str = translate(str, S(from), S(to));
		return str;
	}


#if !defined(NEQUEO_NO_TEMPLATE_ICOMPARE)


	template <class S>
	S& replaceInPlace(S& str, const S& from, const S& to, typename S::size_type start = 0)
	{
		S result;
		typename S::size_type pos = 0;
		result.append(str, 0, start);
		do
		{
			pos = str.find(from, start);
			if (pos != S::npos)
			{
				result.append(str, start, pos - start);
				result.append(to);
				start = pos + from.length();
			}
			else result.append(str, start, str.size() - start);
		} while (pos != S::npos);
		str.swap(result);
		return str;
	}


	template <class S>
	S& replaceInPlace(S& str, const typename S::value_type* from, const typename S::value_type* to, typename S::size_type start = 0)
	{
		S result;
		typename S::size_type pos = 0;
		typename S::size_type fromLen = std::strlen(from);
		result.append(str, 0, start);
		do
		{
			pos = str.find(from, start);
			if (pos != S::npos)
			{
				result.append(str, start, pos - start);
				result.append(to);
				start = pos + fromLen;
			}
			else result.append(str, start, str.size() - start);
		} while (pos != S::npos);
		str.swap(result);
		return str;
	}


	template <class S>
	S replace(const S& str, const S& from, const S& to, typename S::size_type start = 0)
		/// Replace all occurences of from (which must not be the empty string)
		/// in str with to, starting at position start.
	{
		S result(str);
		replaceInPlace(result, from, to, start);
		return result;
	}


	template <class S>
	S replace(const S& str, const typename S::value_type* from, const typename S::value_type* to, typename S::size_type start = 0)
	{
		S result(str);
		replaceInPlace(result, from, to, start);
		return result;
	}


#else


	std::string replace(const std::string& str, const std::string& from, const std::string& to, std::string::size_type start = 0);
	std::string replace(const std::string& str, const std::string::value_type* from, const std::string::value_type* to, std::string::size_type start = 0);
	std::string& replaceInPlace(std::string& str, const std::string& from, const std::string& to, std::string::size_type start = 0);
	std::string& replaceInPlace(std::string& str, const std::string::value_type* from, const std::string::value_type* to, std::string::size_type start = 0);


#endif	


	template <class S>
	S cat(const S& s1, const S& s2)
		/// Concatenates two strings.
	{
		S result = s1;
		result.reserve(s1.size() + s2.size());
		result.append(s2);
		return result;
	}


	template <class S>
	S cat(const S& s1, const S& s2, const S& s3)
		/// Concatenates three strings.
	{
		S result = s1;
		result.reserve(s1.size() + s2.size() + s3.size());
		result.append(s2);
		result.append(s3);
		return result;
	}


	template <class S>
	S cat(const S& s1, const S& s2, const S& s3, const S& s4)
		/// Concatenates four strings.
	{
		S result = s1;
		result.reserve(s1.size() + s2.size() + s3.size() + s4.size());
		result.append(s2);
		result.append(s3);
		result.append(s4);
		return result;
	}


	template <class S>
	S cat(const S& s1, const S& s2, const S& s3, const S& s4, const S& s5)
		/// Concatenates five strings.
	{
		S result = s1;
		result.reserve(s1.size() + s2.size() + s3.size() + s4.size() + s5.size());
		result.append(s2);
		result.append(s3);
		result.append(s4);
		result.append(s5);
		return result;
	}


	template <class S>
	S cat(const S& s1, const S& s2, const S& s3, const S& s4, const S& s5, const S& s6)
		/// Concatenates six strings.
	{
		S result = s1;
		result.reserve(s1.size() + s2.size() + s3.size() + s4.size() + s5.size() + s6.size());
		result.append(s2);
		result.append(s3);
		result.append(s4);
		result.append(s5);
		result.append(s6);
		return result;
	}


	template <class S, class It>
	S cat(const S& delim, const It& begin, const It& end)
		/// Concatenates a sequence of strings, delimited
		/// by the string given in delim.
	{
		S result;
		for (It it = begin; it != end; ++it)
		{
			if (!result.empty()) result.append(delim);
			result += *it;
		}
		return result;
	}
}
#endif